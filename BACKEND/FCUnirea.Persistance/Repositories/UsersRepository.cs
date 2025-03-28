
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
                .AsNoTracking()
                .FirstOrDefault(u => u.Username == username);
        }
    }
}
