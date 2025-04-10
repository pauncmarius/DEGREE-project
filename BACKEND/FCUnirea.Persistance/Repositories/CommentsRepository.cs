
using System.Collections.Generic;
using System.Linq;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Repositories
{
    public class CommentsRepository : BaseRepository<Comments>, ICommentsRepository
    {
        public CommentsRepository(FCUnireaDbContext fcUnireaDbContext): base(fcUnireaDbContext)
        {


        }

        public IEnumerable<Comments> GetByNewsIdWithUser(int newsId)
        {
            return _dbContext.Comments
                .Where(c => c.Comment_NewsId == newsId)
                .Include(c => c.Comment_User) // navigare spre utilizator
                .OrderByDescending(c => c.CreatedAt)
                .ToList();
        }

    }
}
