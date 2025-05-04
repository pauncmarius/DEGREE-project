using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Repositories
{
    public class PlayerStatisticsPerCompetitionRepository : BaseRepository<PlayerStatisticsPerCompetition>, IPlayerStatisticsPerCompetitionRepository
    {
        public PlayerStatisticsPerCompetitionRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext) { }

        public async Task<Dictionary<(int PlayerId, int CompetitionId), int>> GetGoalsGroupedByPlayerAndCompetitionAsync()
        {
            return await (
                from stat in _dbContext.PlayerStatisticsPerGame
                join game in _dbContext.Games on stat.PlayerStatisticsPerGame_GamesId equals game.Id
                where game.IsPlayed &&
                      stat.PlayerStatisticsPerGame_PlayersId.HasValue &&
                      game.Game_CompetitionsId.HasValue
                group stat by new
                {
                    PlayerId = stat.PlayerStatisticsPerGame_PlayersId.Value,
                    CompetitionId = game.Game_CompetitionsId.Value
                } into g
                select new
                {
                    g.Key.PlayerId,
                    g.Key.CompetitionId,
                    Goals = g.Sum(p => p.Goals)
                }
            ).ToDictionaryAsync(
                g => (g.PlayerId, g.CompetitionId),
                g => g.Goals
            );
        }


        public async Task<PlayerStatisticsPerCompetition> GetByPlayerAndCompetitionAsync(int playerId, int competitionId)
        {
            return await _dbContext.PlayerStatisticsPerCompetiton
                .FirstOrDefaultAsync(p =>
                    p.PlayerStatisticsPerCompetition_PlayersId == playerId &&
                    p.PlayerStatisticsPerCompetition_CompetitionsId == competitionId);
        }

        public async Task<IEnumerable<PlayerStatisticsPerCompetition>> GetByPlayerIdAsync(int playerId)
        {
            return await _dbContext.PlayerStatisticsPerCompetiton
                .Where(p => p.PlayerStatisticsPerCompetition_PlayersId == playerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerStatisticsPerCompetition>> GetTopScorersByCompetitionAsync(int competitionId)
        {
            return await _dbContext.PlayerStatisticsPerCompetiton
                .Include(p => p.PlayerStatisticsPerCompetition_Players)
                    .ThenInclude(p => p.Player_Teams) // dacă ai relație de tip Player → Team
                .Where(p => p.PlayerStatisticsPerCompetition_CompetitionsId == competitionId && p.Goals > 0)
                .OrderByDescending(p => p.Goals)
                .Take(10)
                .ToListAsync();
        }

    }
}

