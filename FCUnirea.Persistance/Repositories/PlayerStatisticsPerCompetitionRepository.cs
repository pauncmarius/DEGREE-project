using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Persistance.Repositories
{
    public class PlayerStatisticsPerCompetitonRepository : BaseRepository<PlayerStatisticsPerCompetition>, IPlayerStatisticsPerCompetitionRepository
    {
        public PlayerStatisticsPerCompetitonRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext)
        {

        }
    }
}
