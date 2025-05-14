//IPlayerStatisticsPerCompetitionRepository
using System.Collections.Generic;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface IPlayerStatisticsPerCompetitionRepository : IBaseRepository<PlayerStatisticsPerCompetition>
    {
        Task<Dictionary<(int PlayerId, int CompetitionId), int>> GetGoalsGroupedByPlayerAndCompetitionAsync();
        Task<IEnumerable<PlayerStatisticsPerCompetition>> GetByPlayerIdAsync(int playerId);
        Task<IEnumerable<PlayerStatisticsPerCompetition>> GetTopScorersByCompetitionAsync(int competitionId);

    }
}
