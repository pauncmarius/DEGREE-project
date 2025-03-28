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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace FCUnirea.Business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;


        public UsersService(IUsersRepository userRepository, IMapper mapper, IOptions<JwtSettings> jwtSettings)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;

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
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim("userId", user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
