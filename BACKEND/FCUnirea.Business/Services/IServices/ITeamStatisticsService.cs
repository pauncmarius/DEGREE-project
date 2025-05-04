using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface ITeamStatisticsService
    {
        Task<IEnumerable<TeamStatistics>> GetTeamStatisticsAsync();
        Task<TeamStatistics> GetTeamStatisticAsync(int id);
        Task<int> AddTeamStatisticAsync(TeamStatisticsModel teamStatistic);
        Task UpdateTeamStatisticAsync(TeamStatistics teamStatistic);
        Task DeleteTeamStatisticAsync(int id);
        Task UpdateAllTeamStatisticsFromGamesAsync();

        Task<IEnumerable<TeamStatistics>> GetByCompetitionAsync(int competitionId);
        Task<IEnumerable<TeamStatisticsModel>> GetStandingsByCompetitionAsync(int competitionId);
    }
}
