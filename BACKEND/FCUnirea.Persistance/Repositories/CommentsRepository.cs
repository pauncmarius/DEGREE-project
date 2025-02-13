using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;

namespace FCUnirea.Persistance.Repositories
{
    public class CommentsRepository : BaseRepository<Comments>, ICommentsRepository
    {
        public CommentsRepository(FCUnireaDbContext fcUnireaDbContext): base(fcUnireaDbContext)
        {

        }
    }
}
