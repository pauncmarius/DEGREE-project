//UsersService
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
        public Users GetByUsername(string username) => _userRepository.GetByUsername(username);
        public int AddUser(UsersModel user) => _userRepository.Add(_mapper.Map<Users>(user)).Id;
        public void UpdateUser(Users user) => _userRepository.Update(user);

        public void DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user != null) _userRepository.Delete(user);
        }

        public int? RegisterUser(UsersModel request, out Dictionary<string, string> errors)
        {
            errors = new Dictionary<string, string>();
            var existingUsers = _userRepository.ListAll();

            if (existingUsers.Any(u => u.Username == request.Username))
                errors["username"] = "Acest username este deja utilizat.";

            if (existingUsers.Any(u => u.Email == request.Email))
                errors["email"] = "Acest email este deja utilizat.";

            if (existingUsers.Any(u => u.PhoneNumber == request.PhoneNumber))
                errors["phoneNumber"] = "Acest număr de telefon este deja utilizat.";

            if (errors.Count > 0)
                return null; 

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

        // hashing the pass
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
            // creem o cheie de securitate folosind cheia secreta
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            // semnatura tokenului
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // stabilim datele din token
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("userId", user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
            // creem tokenul
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null || !VerifyPassword(currentPassword, user.Password))
                return false;

            var newHashedPassword = HashPassword(newPassword);
            _userRepository.UpdatePassword(user.Id, newHashedPassword);
            return true;
        }

        public void UpdateName(string username, string firstName, string lastName)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null) return;

            user.FirstName = firstName;
            user.LastName = lastName;
            _userRepository.Update(user);
        }

        public bool UpdateUsername(string currentUsername, string newUsername, out string error)
        {
            error = "";
            if (_userRepository.ListAll().Any(u => u.Username == newUsername))
            {
                error = "Username deja folosit.";
                return false;
            }

            var user = _userRepository.GetByUsername(currentUsername);
            if (user == null) return false;

            user.Username = newUsername;
            _userRepository.Update(user);
            return true;
        }

        public bool UpdateEmail(string currentUsername, string newEmail, out string error)
        {
            error = "";
            if (_userRepository.ListAll().Any(u => u.Email == newEmail))
            {
                error = "Email deja folosit.";
                return false;
            }

            var user = _userRepository.GetByUsername(currentUsername);
            if (user == null) return false;

            user.Email = newEmail;
            _userRepository.Update(user);
            return true;
        }

        public bool UpdatePhone(string currentUsername, string newPhone, out string error)
        {
            error = "";
            if (_userRepository.ListAll().Any(u => u.PhoneNumber == newPhone))
            {
                error = "Telefon deja folosit.";
                return false;
            }

            var user = _userRepository.GetByUsername(currentUsername);
            if (user == null) return false;

            user.PhoneNumber = newPhone;
            _userRepository.Update(user);
            return true;
        }

    }
}
