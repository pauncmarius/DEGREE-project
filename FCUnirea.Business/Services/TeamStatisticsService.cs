using AutoMapper;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services
{
    public class TeamStatisticsService : ITeamStatisticsService
    {
        private readonly ITeamStatisticsRepository _repository;
        private readonly IMapper _mapper;

        public TeamStatisticsService(ITeamStatisticsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TeamStatistics> GetTeamStatistics() => _repository.ListAll();
        public TeamStatistics GetTeamStatistic(int id) => _repository.GetById(id);
        public int AddTeamStatistic(TeamStatistics statistic) => _repository.Add(statistic).Id;
        public void UpdateTeamStatistic(TeamStatistics statistic) => _repository.Update(statistic);
        public void DeleteTeamStatistic(int id)
        {
            var statistic = _repository.GetById(id);
            if (statistic != null) _repository.Delete(statistic);
        }
    }
}
