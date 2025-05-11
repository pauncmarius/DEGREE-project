//IPlayerStatisticsPerGameService
using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface IPlayerStatisticsPerGameService
    {
        Task<IEnumerable<PlayerStatisticsPerGame>> GetPlayerStatisticsPerGamesAsync();
        Task<PlayerStatisticsPerGame> GetPlayerStatisticPerGameAsync(int id);
        Task<int> AddPlayerStatisticPerGameAsync(PlayerStatisticsPerGameModel statistic);
        Task UpdatePlayerStatisticPerGameAsync(PlayerStatisticsPerGame statistic);
        Task<bool> DeletePlayerStatisticPerGameAsync(int id);
        Task<int> AddAndUpdateGameScoreAsync(PlayerStatisticsPerGameModel model);

        Task<IEnumerable<GameScorerModel>> GetScorersForGameAsync(int gameId);

    }
}
