using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System.Collections.Generic;

namespace FCUnirea.Business.Services
{
    public class PlayerStatisticsPerGameService : IPlayerStatisticsPerGameService
    {
        private readonly IPlayerStatisticsPerGameRepository _repository;
        private readonly IMapper _mapper;

        public PlayerStatisticsPerGameService(IPlayerStatisticsPerGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PlayerStatisticsPerGame> GetPlayerStatisticsPerGames() => _repository.ListAll();
        public PlayerStatisticsPerGame GetPlayerStatisticPerGame(int id) => _repository.GetById(id);
        public int AddPlayerStatisticPerGame(PlayerStatisticsPerGameModel statistic) => _repository.Add(_mapper.Map<PlayerStatisticsPerGame>(statistic)).Id;
        public void UpdatePlayerStatisticPerGame(PlayerStatisticsPerGame statistic) => _repository.Update(statistic);
        public void DeletePlayerStatisticPerGame(int id)
        {
            var statistic = _repository.GetById(id);
            if (statistic != null) _repository.Delete(statistic);
        }
    }
}
