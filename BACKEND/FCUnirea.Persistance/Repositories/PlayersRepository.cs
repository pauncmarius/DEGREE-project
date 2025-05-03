
using System.Collections.Generic;
using System.Linq;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;

namespace FCUnirea.Persistance.Repositories
{
    public class PlayersRepository : BaseRepository<Players>, IPlayersRepository
    {
        public PlayersRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext)
        {

        }
        public IEnumerable<Players> GetPlayersByTeam(int teamId)
        {
            return _dbContext.Players.Where(p => p.Player_TeamsId == teamId).ToList();
        }
    }
}
