//IUsersRepository
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        Users Authenticate(string username);
        Users GetByUsername(string username);
        void UpdatePassword(int userId, string newHashedPassword);

    }
}
