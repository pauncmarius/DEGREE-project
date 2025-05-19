//CommentsRepository
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
        public CommentsRepository(FCUnireaDbContext fcUnireaDbContext): base(fcUnireaDbContext){}

        public IEnumerable<Comments> GetByNewsIdWithUser(int newsId)
        {
            // selecteaza comentariile care au id-ul stirei egal cu newsId
            return _dbContext.Comments
                .Where(c => c.Comment_NewsId == newsId)
                // incarca si informatiile despre utilizatorul care a scris comentariul (Include = eager loading)
                .Include(c => c.Comment_User)
                // sorteaza comentariile descrescator dupa data crearii
                .OrderByDescending(c => c.CreatedAt)
                // returneaza rezultatul ca lista
                .ToList();
        }
    }
}
