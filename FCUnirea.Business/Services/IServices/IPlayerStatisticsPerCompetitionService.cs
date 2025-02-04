using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface IPlayerStatisticsPerCompetitionService
    {
        public IEnumerable<PlayerStatisticsPerCompetition> GetPlayerStatisticsPerCompetitions();
        public PlayerStatisticsPerCompetition GetPlayerStatisticPerCompetition(int id);
        public int AddPlayerStatisticPerCompetition(PlayerStatisticsPerCompetitionModel statistic);
        public void UpdatePlayerStatisticPerCompetition(PlayerStatisticsPerCompetition statistic);
        public void DeletePlayerStatisticPerCompetition(int id);
    }
}
