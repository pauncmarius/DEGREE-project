//CompetitionsRepository
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;

namespace FCUnirea.Persistance.Repositories

{
    public class CompetitionsRepository : BaseRepository<Competitions>, ICompetitionsRepository
    {
        public CompetitionsRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext){ }
    }
}
