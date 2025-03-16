using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace FCUnirea.Business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<Users> GetUsers() => _userRepository.ListAll();
        public Users GetUser(int id) => _userRepository.GetById(id);
        public int AddUser(UsersModel user) => _userRepository.Add(_mapper.Map<Users>(user)).Id;
        public void UpdateUser(Users user) => _userRepository.Update(user);

        public void DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user != null) _userRepository.Delete(user);
        }

        public int RegisterUser(UsersModel request)
        {
            var existingUser = _userRepository.ListAll()
                .FirstOrDefault(u => u.Username == request.Username || u.Email == request.Email);

            if (existingUser != null)
            {
                throw new Exception("Un utilizator cu acest username sau email există deja!");
            }

            var user = new Users
            {
                Username = request.Username,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
                CreatedAt = request.CreatedAt,
                Password = HashPassword(request.Password) // Hash-uim parola cu BouncyCastle
            };

            var createdUser = _userRepository.Add(user);
            return createdUser.Id;
        }


        public string Authenticate(UsersModel request)
        {
            var user = _userRepository.ListAll()
                .FirstOrDefault(u => u.Username == request.Username || u.Email == request.Email);

            if (user == null || !VerifyPassword(request.Password, user.Password))
            {
                return null; // Credentialele sunt incorecte
            }

            return GenerateJwtToken(user);
        }

        // Funcție pentru hash-ul parolei folosind BouncyCastle
        private string HashPassword(string password)
        {
            var generator = new Pkcs5S2ParametersGenerator();
            byte[] salt = new byte[16]; // Random salt
            new SecureRandom().NextBytes(salt);

            generator.Init(
                Encoding.UTF8.GetBytes(password),
                salt,
                10000 // Numărul de iterații pentru hashing
            );

            var key = (KeyParameter)generator.GenerateDerivedMacParameters(256);
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(key.GetKey());
        }


        private bool VerifyPassword(string password, string hashedPassword)
        {
            string[] parts = hashedPassword.Split(':');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedHash = Convert.FromBase64String(parts[1]);

            var generator = new Pkcs5S2ParametersGenerator();
            generator.Init(
                Encoding.UTF8.GetBytes(password),
                salt,
                10000
            );

            var key = (KeyParameter)generator.GenerateDerivedMacParameters(256);
            byte[] computedHash = key.GetKey();

            return storedHash.SequenceEqual(computedHash);
        }

        private string GenerateJwtToken(Users user)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Username));
        }
    }
}
