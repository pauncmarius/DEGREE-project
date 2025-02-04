using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface IPlayerStatisticsPerGameService
    {
        public IEnumerable<PlayerStatisticsPerGame> GetPlayerStatisticsPerGames();
        public PlayerStatisticsPerGame GetPlayerStatisticPerGame(int id);
        public int AddPlayerStatisticPerGame(PlayerStatisticsPerGameModel statistic);
        public void UpdatePlayerStatisticPerGame(PlayerStatisticsPerGame statistic);
        public void DeletePlayerStatisticPerGame(int id);
    }
}
