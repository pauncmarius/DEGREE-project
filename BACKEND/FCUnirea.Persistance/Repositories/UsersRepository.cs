//UsersRepository
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FCUnirea.Persistance.Repositories
{
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        private readonly FCUnireaDbContext _context;

        public UsersRepository(FCUnireaDbContext context) : base(context)
        {
            _context = context;
        }

        public Users Authenticate(string username)
        {
            return _context.Users
                 //nu incarca entitatea pentru tracking
                .AsNoTracking()
                .FirstOrDefault(u => u.Username == username);
        }

        public Users GetByUsername(string username)
        {
            return _context.Users
                .FirstOrDefault(u => u.Username == username);
        }

        public void UpdatePassword(int userId, string newHashedPassword)
        {
            var user = _context.Users.Find(userId);
            if (user == null) return;

            user.Password = newHashedPassword;
            _context.Users.Update(user);
            _context.SaveChanges();
        }

    }
}
