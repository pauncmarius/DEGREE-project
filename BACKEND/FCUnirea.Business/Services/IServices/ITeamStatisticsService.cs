
using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface ITeamStatisticsService
    {
        public IEnumerable<TeamStatistics> GetTeamStatistics();
        public TeamStatistics GetTeamStatistic(int id);
        public int AddTeamStatistic(TeamStatisticsModel teamStatistic);
        public void UpdateTeamStatistic(TeamStatistics teamStatistic);
        public void DeleteTeamStatistic(int id);
    }
}
