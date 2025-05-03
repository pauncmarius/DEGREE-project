using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface IPlayerStatisticsPerCompetitionService
    {
        Task<IEnumerable<PlayerStatisticsPerCompetition>> GetPlayerStatisticsPerCompetitionsAsync();
        Task<PlayerStatisticsPerCompetition> GetPlayerStatisticPerCompetitionAsync(int id);
        Task<int> AddPlayerStatisticPerCompetitionAsync(PlayerStatisticsPerCompetitionModel statistic);
        Task UpdatePlayerStatisticPerCompetitionAsync(PlayerStatisticsPerCompetition statistic);
        Task DeletePlayerStatisticPerCompetitionAsync(int id);
        Task UpdateStatisticsFromGamesAsync();
        Task<IEnumerable<PlayerStatisticsPerCompetition>> GetByPlayerIdAsync(int playerId); // 👈 nou

    }
}
