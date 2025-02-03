using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface ITeamStatisticsService
    {
        IEnumerable<TeamStatistics> GetTeamStatistics();
        TeamStatistics GetTeamStatistic(int id);
        int AddTeamStatistic(TeamStatisticsModel teamStatistic);
        void UpdateTeamStatistic(TeamStatistics teamStatistic);
        void DeleteTeamStatistic(int id);
    }
}
