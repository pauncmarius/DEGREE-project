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
    public class PlayerStatisticsPerCompetitionService : IPlayerStatisticsPerCompetitionService
    {
        private readonly IPlayerStatisticsPerCompetitionRepository _repository;
        private readonly IMapper _mapper;

        public PlayerStatisticsPerCompetitionService(IPlayerStatisticsPerCompetitionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PlayerStatisticsPerCompetition> GetPlayerStatisticsPerCompetitions() => _repository.ListAll();
        public PlayerStatisticsPerCompetition GetPlayerStatisticPerCompetition(int id) => _repository.GetById(id);
        public int AddPlayerStatisticPerCompetition(PlayerStatisticsPerCompetition statistic) => _repository.Add(statistic).Id;
        public void UpdatePlayerStatisticPerCompetition(PlayerStatisticsPerCompetition statistic) => _repository.Update(statistic);
        public void DeletePlayerStatisticPerCompetition(int id)
        {
            var statistic = _repository.GetById(id);
            if (statistic != null) _repository.Delete(statistic);
        }
    }
}
