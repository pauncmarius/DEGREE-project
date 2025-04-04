
using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface IUsersService
    {
        public IEnumerable<Users> GetUsers();
        public Users GetUser(int id);
        public int AddUser(UsersModel user);
        public void UpdateUser(Users user);
        public void DeleteUser(int id);
        //
        public int? RegisterUser(UsersModel request, out Dictionary<string, string> errors);
        public string Authenticate(LoginModel request);
        bool ChangePassword(string username, string currentPassword, string newPassword);
        Users GetByUsername(string username);
        void UpdateName(string username, string firstName, string lastName);
        bool UpdateUsername(string username1, string username2, out string error);
        bool UpdateEmail(string username, string email, out string error);
        bool UpdatePhone(string username, string phoneNumber, out string error);
    }
}
