
using System.Collections.Generic;
using System.Linq;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Repositories
{
    public class GamesRepository : BaseRepository<Games>, IGamesRepository
    {
        public GamesRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext)
        {

        }

        public IEnumerable<Games> GetGamesByTeam(int teamId)
        {
            return _dbContext.Games
                .Include(g => g.Game_HomeTeam)
                .Include(g => g.Game_AwayTeam)
                .Include(g => g.Game_Competitions)
                .Where(g => g.Game_HomeTeamId == teamId || g.Game_AwayTeamId == teamId)
                .OrderBy(g => g.GameDate)
                .ToList();
        }
    }
}
