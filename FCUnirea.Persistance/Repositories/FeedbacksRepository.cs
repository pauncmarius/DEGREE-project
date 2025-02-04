using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;

namespace FCUnirea.Persistance.Repositories
{
    public class FeedbacksRepository : BaseRepository<Feedbacks>, IFeedbacksRepository
    {
        public FeedbacksRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext)
        {

        }
    }
}
