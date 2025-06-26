//NewsRepository
using System.Linq;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Repositories
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        public NewsRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext){}

        public News GetByIdWithAuthor(int id)
        {
            return _dbContext.News
                .Include(n => n.News_Users)
                .FirstOrDefault(n => n.Id == id);
        }

    }
}
