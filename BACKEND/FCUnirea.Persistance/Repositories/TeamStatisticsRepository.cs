//TeamStatisticsRepository
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Repositories
{
    public class TeamStatisticsRepository : BaseRepository<TeamStatistics>, ITeamStatisticsRepository
    {
        public TeamStatisticsRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext)
        {
        }

        public async Task<IEnumerable<TeamStatistics>> GetByCompetitionAsync(int competitionId)
        {
            return await _dbContext.TeamStatistics
                .Where(t => t.TeamStatistics_CompetitionsId == competitionId)
                .OrderByDescending(t => t.TotalPoints)
                .ThenByDescending(t => t.GoalsScored - t.GoalsConceded)
                .ToListAsync();
        }

        public async Task<IEnumerable<TeamStatistics>> GetStandingsByCompetitionAsync(int competitionId)
        {
            return await _dbContext.TeamStatistics
                .Where(ts => ts.TeamStatistics_CompetitionsId == competitionId)
                .OrderByDescending(ts => ts.TotalPoints)
                .ThenByDescending(ts => ts.GoalsScored - ts.GoalsConceded)
                .ThenByDescending(ts => ts.GoalsScored)
                .ToListAsync();
        }

    }
}
