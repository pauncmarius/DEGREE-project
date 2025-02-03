using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System.Collections.Generic;


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
        public int AddPlayerStatisticPerCompetition(PlayerStatisticsPerCompetitionModel statistic) => _repository.Add(_mapper.Map<PlayerStatisticsPerCompetition>(statistic)).Id;
        public void UpdatePlayerStatisticPerCompetition(PlayerStatisticsPerCompetition statistic) => _repository.Update(statistic);
        public void DeletePlayerStatisticPerCompetition(int id)
        {
            var statistic = _repository.GetById(id);
            if (statistic != null) _repository.Delete(statistic);
        }
    }
}
