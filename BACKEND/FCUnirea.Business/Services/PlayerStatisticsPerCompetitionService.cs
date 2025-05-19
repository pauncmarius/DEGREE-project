//PlayerStatisticsPerCompetitionService
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<PlayerStatisticsPerCompetition>> GetPlayerStatisticsPerCompetitionsAsync() => await _repository.ListAllAsync();

        public async Task<PlayerStatisticsPerCompetition> GetPlayerStatisticPerCompetitionAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<int> AddPlayerStatisticPerCompetitionAsync(PlayerStatisticsPerCompetitionModel statistic)
        {
            var entity = _mapper.Map<PlayerStatisticsPerCompetition>(statistic);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdatePlayerStatisticPerCompetitionAsync(PlayerStatisticsPerCompetition statistic)
        {
            _repository.Update(statistic);
            await _repository.SaveChangesAsync();
        }

        public async Task DeletePlayerStatisticPerCompetitionAsync(int id)
        {
            var statistic = await _repository.GetByIdAsync(id);
            if (statistic != null)
            {
                _repository.Delete(statistic);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task UpdateStatisticsFromGamesAsync()
        {
            var all = await _repository.ListAllAsync();
            foreach (var entry in all)
            {
                _repository.Delete(entry);
            }
            await _repository.SaveChangesAsync();

            var groupedGoals = await _repository.GetGoalsGroupedByPlayerAndCompetitionAsync();

            foreach (var entry in groupedGoals)
            {
                var (playerId, competitionId) = entry.Key;
                var totalGoals = entry.Value;

                await _repository.AddAsync(new PlayerStatisticsPerCompetition
                {
                    PlayerStatisticsPerCompetition_PlayersId = playerId,
                    PlayerStatisticsPerCompetition_CompetitionsId = competitionId,
                    Goals = totalGoals
                });
            }

            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PlayerStatisticsPerCompetition>> GetByPlayerIdAsync(int playerId)
        {
            return await _repository.GetByPlayerIdAsync(playerId);
        }
        public async Task<IEnumerable<ScorerModel>> GetTopScorersByCompetitionAsync(int competitionId)
        {
            var stats = await _repository.GetTopScorersByCompetitionAsync(competitionId);

            return stats.Select(s => new ScorerModel
            {
                PlayerName = s.PlayerStatisticsPerCompetition_Players.PlayerName,
                TeamName = s.PlayerStatisticsPerCompetition_Players.Player_Teams?.TeamName ?? "Necunoscut",
                Goals = s.Goals
            });
        }



    }
}
