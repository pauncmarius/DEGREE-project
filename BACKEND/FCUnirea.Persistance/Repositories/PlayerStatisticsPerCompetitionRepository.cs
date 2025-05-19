//PlayerStatisticsPerCompetitionRepository
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
            // grupeaza golurile inscrise de fiecare jucator in fiecare competitie si returneaza rezultatul ca dictionar
            return await (
                // selecteaza statisticile jucatorilor din fiecare meci
                from stat in _dbContext.PlayerStatisticsPerGame
                    // face join cu tabela Games ca sa poata prelua competitia fiecarui meci
                join game in _dbContext.Games on stat.PlayerStatisticsPerGame_GamesId equals game.Id
                // filtreaza doar meciurile care au fost jucate si statisticile care au jucator si competitie valid
                where game.IsPlayed &&
                      stat.PlayerStatisticsPerGame_PlayersId.HasValue &&
                      game.Game_CompetitionsId.HasValue
                // grupeaza dupa id-ul jucatorului si id-ul competitiei
                group stat by new
                {
                    PlayerId = stat.PlayerStatisticsPerGame_PlayersId.Value,
                    CompetitionId = game.Game_CompetitionsId.Value
                } into g
                // pentru fiecare grup, extrage id-urile si  fa suma golurilor
                select new
                {
                    g.Key.PlayerId,
                    g.Key.CompetitionId,
                    Goals = g.Sum(p => p.Goals)
                }
            // transforma rezultatul in dictionar cu cheia (PlayerId, CompetitionId) si valoarea totalul golurilor
            ).ToDictionaryAsync(
                g => (g.PlayerId, g.CompetitionId),
                g => g.Goals
            );
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
                    // pentru fiecare jucator, incarca si echipa din care face parte (Player_Teams)
                    .ThenInclude(p => p.Player_Teams)
                .Where(p => p.PlayerStatisticsPerCompetition_CompetitionsId == competitionId && p.Goals > 0)
                .OrderByDescending(p => p.Goals)
                .Take(10)
                .ToListAsync();
        }

    }
}

