using System.Collections.Generic;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface IPlayerStatisticsPerCompetitionRepository : IBaseRepository<PlayerStatisticsPerCompetition>
    {
        Task<Dictionary<(int PlayerId, int CompetitionId), int>> GetGoalsGroupedByPlayerAndCompetitionAsync();
        Task<PlayerStatisticsPerCompetition> GetByPlayerAndCompetitionAsync(int playerId, int competitionId);
    }
}
