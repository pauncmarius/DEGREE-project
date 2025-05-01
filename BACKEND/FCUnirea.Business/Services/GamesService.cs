
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System.Collections.Generic;

namespace FCUnirea.Business.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IMapper _mapper;
        private readonly ITeamStatisticsService _teamStatisticsService;


        public GamesService(IGamesRepository gamesRepository, IMapper mapper, ITeamStatisticsService teamStatisticsService)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
            _teamStatisticsService = teamStatisticsService;
        }

        public IEnumerable<Games> GetGames() => _gamesRepository.ListAll();
        public Games GetGame(int id) => _gamesRepository.GetById(id);
        public int AddGame(GamesModel game) => _gamesRepository.Add(_mapper.Map<Games>(game)).Id;
        public void UpdateGame(Games game)
        {
            var existing = _gamesRepository.GetById(game.Id);

            bool wasNotPlayed = existing != null && existing.IsPlayed == false;
            bool nowPlayed = game.IsPlayed == true;

            _gamesRepository.Update(game);

            // dacă acum devine jucat și nu era înainte
            if (wasNotPlayed && nowPlayed)
            {
                _teamStatisticsService.UpdateAllTeamStatisticsFromGamesAsync();
            }
        }

        public void DeleteGame(int id)
        {
            var game = _gamesRepository.GetById(id);
            if (game != null) _gamesRepository.Delete(game);
        }
    }
}
