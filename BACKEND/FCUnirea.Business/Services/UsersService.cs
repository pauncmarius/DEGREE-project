using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Security.Cryptography;


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
            var existingUsers = _userRepository.ListAll();
            var errors = new Dictionary<string, string>();

            if (existingUsers.Any(u => u.Username == request.Username))
            {
                errors["username"] = "Acest username este deja utilizat.";
            }
            if (existingUsers.Any(u => u.Email == request.Email))
            {
                errors["email"] = "Acest email este deja utilizat.";
            }
            if (existingUsers.Any(u => u.PhoneNumber == request.PhoneNumber))
            {
                errors["phoneNumber"] = "Acest număr de telefon este deja utilizat.";
            }
            if (errors.Count > 0)
            {
                throw new ValidationException(JsonConvert.SerializeObject(errors));
            }

            // folosirea AutoMapper pentru mapare
            var user = _mapper.Map<Users>(request);
            user.Password = HashPassword(request.Password);

            return _userRepository.Add(user).Id;
        }


        public string Authenticate(LoginModel request)
        {
            var user = _userRepository.Authenticate(request.Username);

            if (user == null || !VerifyPassword(request.Password, user.Password))
            {
                return null; // credentialele sunt incorecte
            }

            return GenerateJwtToken(user);
        }

        // hash parola
        private string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        // verifica parola
        private bool VerifyPassword(string password, string storedPassword)
        {
            string[] parts = storedPassword.Split(':');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedHash = Convert.FromBase64String(parts[1]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] computedHash = pbkdf2.GetBytes(32);

            return computedHash.SequenceEqual(storedHash);
        }


        private string GenerateJwtToken(Users user)
        {
            // aici convertim username-ul intr-un string Base64 simplu
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Username));
        }
    }
}
