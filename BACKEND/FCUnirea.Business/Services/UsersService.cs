using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

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

        // functie pentru hash-ul parolei folosind BouncyCastle
        private string HashPassword(string password)
        {
            // creem un generator pentru hash-uri folosind algoritmul PBKDF2
            var generator = new Pkcs5S2ParametersGenerator();
            // creem un array de 16 bytes pentru criptare
            byte[] guard = new byte[16];
            // umplem array-ul „guard” cu valori complet aleatoare
            new SecureRandom().NextBytes(guard);

            // initializam generatorul cu parola, guardul si nr de iteratii
            generator.Init(
                Encoding.UTF8.GetBytes(password),
                guard,
                10000 // nr de iterații pentru hashing
            );

            // generam hash-ul propriu-zis, lung de 256 bits
            var key = (KeyParameter)generator.GenerateDerivedMacParameters(256);
            // returnam guardul si hash-ul sub forma unui singur string, separat prin doua puncte ":"
            return Convert.ToBase64String(guard) + ":" + Convert.ToBase64String(key.GetKey());
        }


        private bool VerifyPassword(string password, string hashedPassword)
        {
            string[] parts = hashedPassword.Split(':');
            if (parts.Length != 2) return false;

            byte[] guard = Convert.FromBase64String(parts[0]);
            byte[] storedHash = Convert.FromBase64String(parts[1]);

            var generator = new Pkcs5S2ParametersGenerator();
            generator.Init(
                Encoding.UTF8.GetBytes(password),
                guard,
                10000
            );

            var key = (KeyParameter)generator.GenerateDerivedMacParameters(256);
            byte[] computedHash = key.GetKey();

            return storedHash.SequenceEqual(computedHash);
        }

        private string GenerateJwtToken(Users user)
        {
            // aici convertim username-ul intr-un string Base64 simplu
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Username));
        }
    }
}
