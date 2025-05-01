using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System;
using System.Collections.Generic;
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

        public async Task<int> AddPlayerStatisticPerGameAsync(PlayerStatisticsPerGameModel statistic)
        {
            var entity = _mapper.Map<PlayerStatisticsPerGame>(statistic);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity.Id;
        }

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
                var player = await _playerRepository.GetByIdAsync(statistic.PlayerStatisticsPerGame_PlayersId ?? 0);

                if (game != null && player != null && player.Player_TeamsId.HasValue)
                {
                    if (game.Game_HomeTeamId == player.Player_TeamsId)
                        game.HomeTeamScore -= statistic.Goals;
                    else if (game.Game_AwayTeamId == player.Player_TeamsId)
                        game.AwayTeamScore -= statistic.Goals;

                    await _gameRepository.UpdateAsync(game);
                    await _gameRepository.SaveChangesAsync();
                }

                await _repository.DeleteAsync(statistic);
                await _repository.SaveChangesAsync();

                await _compstatsService.UpdateStatisticsFromGamesAsync(); // 👈 actualizare clară competiție după ștergere

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

                var game = await _gameRepository.GetByIdAsync(model.PlayerStatisticsPerGame_GamesId.Value);
                var player = await _playerRepository.GetByIdAsync(model.PlayerStatisticsPerGame_PlayersId.Value);

                if (game == null || player == null || !player.Player_TeamsId.HasValue)
                    throw new Exception("Game or Player not found");

                bool wasNotPlayed = !game.IsPlayed;
                game.IsPlayed = true;

                if (game.Game_HomeTeamId == player.Player_TeamsId)
                    game.HomeTeamScore += model.Goals;
                else if (game.Game_AwayTeamId == player.Player_TeamsId)
                    game.AwayTeamScore += model.Goals;

                await _gameRepository.UpdateAsync(game);

                // 👇 SALVEZI întâi toate datele înainte de recalcul
                await _repository.SaveChangesAsync();
                await _gameRepository.SaveChangesAsync();

                // 👇 abia ACUM actualizezi competițiile și statisticile echipelor
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


    }
}
