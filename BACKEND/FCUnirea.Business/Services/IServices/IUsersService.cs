
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
        public int RegisterUser(UsersModel request);
        public string Authenticate(UsersModel request);

    }
}
