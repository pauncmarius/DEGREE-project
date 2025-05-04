using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services
{
    public class TeamStatisticsService : ITeamStatisticsService
    {
        private readonly ITeamStatisticsRepository _repository;
        private readonly IGamesRepository _gamesRepository;
        private readonly IMapper _mapper;

        public TeamStatisticsService(ITeamStatisticsRepository repository, IMapper mapper, IGamesRepository gamesRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _gamesRepository = gamesRepository;
        }

        public async Task<IEnumerable<TeamStatistics>> GetTeamStatisticsAsync() =>
            await _repository.ListAllAsync();

        public async Task<TeamStatistics> GetTeamStatisticAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<int> AddTeamStatisticAsync(TeamStatisticsModel statistic)
        {
            var entity = _mapper.Map<TeamStatistics>(statistic);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateTeamStatisticAsync(TeamStatistics statistic)
        {
            await _repository.UpdateAsync(statistic);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteTeamStatisticAsync(int id)
        {
            var statistic = await _repository.GetByIdAsync(id);
            if (statistic != null)
            {
                await _repository.DeleteAsync(statistic);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task UpdateAllTeamStatisticsFromGamesAsync()
        {
            // 🔴 ȘTERGI toate statisticile existente
            var existing = await _repository.ListAllAsync();
            foreach (var stat in existing)
            {
                _repository.Delete(stat);
            }
            await _repository.SaveChangesAsync();

            var playedGames = (await _gamesRepository.ListAllAsync())
                .Where(g => g.IsPlayed && g.Game_CompetitionsId.HasValue)
                .ToList();

            var teamStats = new Dictionary<(int teamId, int competitionId), TeamStatistics>();

            foreach (var game in playedGames)
            {
                int homeId = game.Game_HomeTeamId ?? 0;
                int awayId = game.Game_AwayTeamId ?? 0;
                int competitionId = game.Game_CompetitionsId ?? 0;

                UpdateStats(teamStats, homeId, competitionId,
                    goalsScored: game.HomeTeamScore,
                    goalsConceded: game.AwayTeamScore,
                    result: GetResult(game.HomeTeamScore, game.AwayTeamScore));

                UpdateStats(teamStats, awayId, competitionId,
                    goalsScored: game.AwayTeamScore,
                    goalsConceded: game.HomeTeamScore,
                    result: GetResult(game.AwayTeamScore, game.HomeTeamScore));
            }

            foreach (var stat in teamStats.Values)
            {
                await _repository.AddAsync(stat);
            }

            await _repository.SaveChangesAsync();
        }


        private void UpdateStats(
            Dictionary<(int teamId, int competitionId), TeamStatistics> stats,
            int teamId, int competitionId,
            int goalsScored, int goalsConceded, string result)
        {
            var key = (teamId, competitionId);
            if (!stats.ContainsKey(key))
            {
                stats[key] = new TeamStatistics
                {
                    TeamsStatistics_TeamsId = teamId,
                    TeamStatistics_CompetitionsId = competitionId
                };
            }

            var teamStat = stats[key];
            teamStat.GamesPlayed++;
            teamStat.GoalsScored += goalsScored;
            teamStat.GoalsConceded += goalsConceded;

            switch (result)
            {
                case "WIN":
                    teamStat.TotalWins++;
                    teamStat.TotalPoints += 3;
                    break;
                case "DRAW":
                    teamStat.TotalDraws++;
                    teamStat.TotalPoints += 1;
                    break;
                case "LOSS":
                    teamStat.TotalLosses++;
                    break;
            }
        }

        private string GetResult(int scored, int conceded)
        {
            if (scored > conceded) return "WIN";
            if (scored < conceded) return "LOSS";
            return "DRAW";
        }

        public async Task<IEnumerable<TeamStatistics>> GetByCompetitionAsync(int competitionId)
        {
            return await _repository.GetByCompetitionAsync(competitionId); // 👈 nou
        }

        public async Task<IEnumerable<TeamStatisticsModel>> GetStandingsByCompetitionAsync(int competitionId)
        {
            var standings = await _repository.GetStandingsByCompetitionAsync(competitionId);
            var allTeams = await _gamesRepository.GetTeamsAsync(); // ai nevoie de această metodă

            var result = standings.Select(s =>
            {
                var model = _mapper.Map<TeamStatisticsModel>(s);
                var team = allTeams.FirstOrDefault(t => t.Id == s.TeamsStatistics_TeamsId);
                model.TeamName = team?.TeamName ?? "Necunoscut";
                return model;
            });

            return result;
        }


    }
}
