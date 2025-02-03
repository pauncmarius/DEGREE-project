using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface IPlayerStatisticsPerCompetitionService
    {
        IEnumerable<PlayerStatisticsPerCompetition> GetPlayerStatisticsPerCompetitions();
        PlayerStatisticsPerCompetition GetPlayerStatisticPerCompetition(int id);
        int AddPlayerStatisticPerCompetition(PlayerStatisticsPerCompetitionModel statistic);
        void UpdatePlayerStatisticPerCompetition(PlayerStatisticsPerCompetition statistic);
        void DeletePlayerStatisticPerCompetition(int id);
    }
}
