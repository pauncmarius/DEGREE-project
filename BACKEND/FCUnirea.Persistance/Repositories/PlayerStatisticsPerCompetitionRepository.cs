
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;

namespace FCUnirea.Persistance.Repositories
{
    public class PlayerStatisticsPerCompetitionRepository : BaseRepository<PlayerStatisticsPerCompetition>, IPlayerStatisticsPerCompetitionRepository
    {
        public PlayerStatisticsPerCompetitionRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext)
        {

        }
    }
}
