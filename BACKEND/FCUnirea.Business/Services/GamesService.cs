//GamesService
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Repositories;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<GameWithTeamNamesModel> GetGamesWithTeamNamesByTeam(int teamId)
        {
            var games = _gamesRepository.GetGamesByTeam(teamId);

            return games.Select(g => new GameWithTeamNamesModel
            {
                Id = g.Id,
                GameDate = g.GameDate,
                HomeTeamScore = g.HomeTeamScore,
                AwayTeamScore = g.AwayTeamScore,
                IsPlayed = g.IsPlayed,
                HomeTeamName = g.Game_HomeTeam?.TeamName ?? "N/A",
                AwayTeamName = g.Game_AwayTeam?.TeamName ?? "N/A",
                CompetitionName = g.Game_Competitions?.CompetitionName ?? "Necunoscut",
                Game_CompetitionsId = g.Game_CompetitionsId ?? 0,

                Game_HomeTeamId = g.Game_HomeTeamId ?? 0,
                Game_AwayTeamId = g.Game_AwayTeamId ?? 0

            });
        }

        public IEnumerable<GameForTicketModel> GetHomeUpcomingGames()
        {
            var games = _gamesRepository.GetAvailableHomeGames();

            return games.Select(g => new GameForTicketModel
            {
                Id = g.Id,
                GameDate = g.GameDate,
                HomeTeamName = g.Game_HomeTeam?.TeamName ?? "",
                AwayTeamName = g.Game_AwayTeam?.TeamName ?? "",
                CompetitionName = g.Game_Competitions?.CompetitionName ?? "",
                StadiumName = g.Game_Stadiums?.StadiumName ?? "",
                StadiumLocation = g.Game_Stadiums?.StadiumLocation ?? ""
            });
        }

        public IEnumerable<GameWithTeamNamesModel> GetAllGamesWithNames()
        {
            var games = _gamesRepository.ListAllWithIncludes();

            return games.Select(g => new GameWithTeamNamesModel
            {
                Id = g.Id,
                GameDate = g.GameDate,
                HomeTeamScore = g.HomeTeamScore,
                AwayTeamScore = g.AwayTeamScore,
                IsPlayed = g.IsPlayed,
                HomeTeamName = g.Game_HomeTeam?.TeamName ?? "",
                AwayTeamName = g.Game_AwayTeam?.TeamName ?? "",
                CompetitionName = g.Game_Competitions?.CompetitionName ?? "",
                Game_HomeTeamId = g.Game_HomeTeamId ?? 0,
                Game_AwayTeamId = g.Game_AwayTeamId ?? 0,
                Game_CompetitionsId = g.Game_CompetitionsId ?? 0
            });
        }


    }
}
