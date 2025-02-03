using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface IPlayerStatisticsPerGameService
    {
        IEnumerable<PlayerStatisticsPerGame> GetPlayerStatisticsPerGames();
        PlayerStatisticsPerGame GetPlayerStatisticPerGame(int id);
        int AddPlayerStatisticPerGame(PlayerStatisticsPerGameModel statistic);
        void UpdatePlayerStatisticPerGame(PlayerStatisticsPerGame statistic);
        void DeletePlayerStatisticPerGame(int id);
    }
}
