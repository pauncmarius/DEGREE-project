using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface IUsersService
    {
        IEnumerable<Users> GetUsers();
        Users GetUser(int id);
        int AddUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(int id);
    }
}
