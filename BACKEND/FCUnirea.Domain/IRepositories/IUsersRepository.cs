
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        Users RegisterUser(Users user);
        Users Authenticate(string username);
    }
}
