//PlayerStatisticsPerGameService
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services
{
    public class PlayerStatisticsPerGameService : IPlayerStatisticsPerGameService
    {
        private readonly IPlayerStatisticsPerGameRepository _repository;
        private readonly IGamesRepository _gameRepository;
        private readonly IPlayersRepository _playerRepository;
        private readonly ITeamStatisticsService _teamStatisticsService;
        private readonly IPlayerStatisticsPerCompetitionService _compstatsService;
        private readonly IMapper _mapper;

        public PlayerStatisticsPerGameService(
            IGamesRepository gameRepository,
            IPlayersRepository playerRepository,
            IPlayerStatisticsPerGameRepository repository,
            IMapper mapper,
            ITeamStatisticsService teamStatisticsService,
            IPlayerStatisticsPerCompetitionService compstatsService)
        {
            _repository = repository;
            _mapper = mapper;
            _teamStatisticsService = teamStatisticsService;
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _compstatsService = compstatsService;
        }

        public async Task<IEnumerable<PlayerStatisticsPerGame>> GetPlayerStatisticsPerGamesAsync() =>
            await _repository.ListAllAsync();

        public async Task<PlayerStatisticsPerGame> GetPlayerStatisticPerGameAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task UpdatePlayerStatisticPerGameAsync(PlayerStatisticsPerGame statistic)
        {
            await _repository.UpdateAsync(statistic);
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeletePlayerStatisticPerGameAsync(int id)
        {
            await _repository.BeginTransactionAsync();
            try
            {
                var statistic = await _repository.GetByIdAsync(id);
                if (statistic == null) return false;

                var game = await _gameRepository.GetByIdAsync(statistic.PlayerStatisticsPerGame_GamesId ?? 0);
                // sterge mrcatorul din tabela playerstatisticspergame
                await _repository.DeleteAsync(statistic);
                await _repository.SaveChangesAsync();

                if (game != null)
                {
                    await RecalculateGameScoreAsync(game);
                    await _gameRepository.UpdateAsync(game);
                    await _gameRepository.SaveChangesAsync();
                }

                await _compstatsService.UpdateStatisticsFromGamesAsync();

                await _repository.CommitTransactionAsync();
                return true;
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<int> AddAndUpdateGameScoreAsync(PlayerStatisticsPerGameModel model)
        {
            await _repository.BeginTransactionAsync();
            try
            {
                var entity = _mapper.Map<PlayerStatisticsPerGame>(model);
                await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();

                var game = await _gameRepository.GetByIdAsync(model.PlayerStatisticsPerGame_GamesId.Value);

                if (game == null)
                    throw new Exception("Game not found");

                game.IsPlayed = true;

                // Recalculam scorul meciului
                await RecalculateGameScoreAsync(game);
                await _gameRepository.UpdateAsync(game);

                await _gameRepository.SaveChangesAsync();
                await _teamStatisticsService.UpdateAllTeamStatisticsFromGamesAsync();
                await _compstatsService.UpdateStatisticsFromGamesAsync();

                await _repository.CommitTransactionAsync();
                return entity.Id;
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }



        public async Task<IEnumerable<GameScorerModel>> GetScorersForGameAsync(int gameId)
        {
            var scorers = await _repository.GetScorersByGameAsync(gameId);
            return scorers.Select(p => new GameScorerModel
            {
                Id = p.Id,
                PlayerName = p.PlayerStatisticsPerGame_Players.PlayerName,
                TeamName = p.PlayerStatisticsPerGame_Players.Player_Teams?.TeamName ?? "Necunoscut",
                Goals = p.Goals
            });
        }

        private async Task RecalculateGameScoreAsync(Games game)
        {
            var allScorers = await _repository.GetScorersByGameAsync(game.Id);
            int homeGoals = 0, awayGoals = 0;
            foreach (var scorer in allScorers)
            {
                var player = scorer.PlayerStatisticsPerGame_Players;
                if (player.Player_TeamsId == game.Game_HomeTeamId)
                    homeGoals += scorer.Goals;
                else if (player.Player_TeamsId == game.Game_AwayTeamId)
                    awayGoals += scorer.Goals;
            }
            game.HomeTeamScore = homeGoals;
            game.AwayTeamScore = awayGoals;
        }



    }
}
