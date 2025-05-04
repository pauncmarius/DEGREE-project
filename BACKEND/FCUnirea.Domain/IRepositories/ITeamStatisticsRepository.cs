
using System.Collections.Generic;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface ITeamStatisticsRepository : IBaseRepository<TeamStatistics>
    {

        Task<IEnumerable<TeamStatistics>> GetByCompetitionAsync(int competitionId);
        Task<IEnumerable<TeamStatistics>> GetStandingsByCompetitionAsync(int competitionId);

    }

}
