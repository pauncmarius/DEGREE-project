//GamesRepository
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Repositories
{
    public class GamesRepository : BaseRepository<Games>, IGamesRepository
    {
        public GamesRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext){}

        public IEnumerable<Games> GetGamesByTeam(int teamId)
        {
            return _dbContext.Games
                .Include(g => g.Game_HomeTeam)
                .Include(g => g.Game_AwayTeam)
                .Include(g => g.Game_Competitions)
                // filtreaza meciurile in care echipa cautata e fie gazda, fie oaspete
                .Where(g => g.Game_HomeTeamId == teamId || g.Game_AwayTeamId == teamId)
                .OrderBy(g => g.GameDate)
                .ToList();
        }

        public async Task<IEnumerable<Teams>> GetTeamsAsync()
        {
            return await _dbContext.Teams.ToListAsync();
        }

        public IEnumerable<Games> GetAvailableHomeGames()
        {
            var internalStadiumIds = new[] { 1, 11, 21 };

            return _dbContext.Games
                .Include(g => g.Game_HomeTeam)
                .Include(g => g.Game_AwayTeam)
                .Include(g => g.Game_Competitions)
                .Include(g => g.Game_Stadiums)
                .Where(g => !g.IsPlayed && internalStadiumIds.Contains(g.Game_StadiumsId ?? -1))
                .OrderBy(g => g.GameDate)
                .ToList();
        }

        public async Task<Games?> GetGameWithDetailsAsync(int id)
        {
            return await _dbContext.Games
                .Include(g => g.Game_HomeTeam)
                .Include(g => g.Game_AwayTeam)
                .Include(g => g.Game_Stadiums)
                // cauta primul meci care are id-ul dorit (g.Id == id)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Games> GetByIdWithStadiumAsync(int gameId)
        {
            return await _dbContext.Games
                .Include(g => g.Game_Stadiums)
                .FirstOrDefaultAsync(g => g.Id == gameId);
        }

        public IEnumerable<Games> ListAllWithIncludes()
        {
            return _dbContext.Games
                .Include(g => g.Game_HomeTeam)
                .Include(g => g.Game_AwayTeam)
                .Include(g => g.Game_Competitions)
                .ToList();
        }

        public IEnumerable<Games> GetGamesByCompetition(int competitionId)
        {
            return _dbContext.Games
                .Include(g => g.Game_HomeTeam)
                .Include(g => g.Game_AwayTeam)
                .Include(g => g.Game_Competitions)
                .Where(g => g.Game_CompetitionsId == competitionId)
                .OrderBy(g => g.GameDate)
                .ToList();
        }


    }
}
