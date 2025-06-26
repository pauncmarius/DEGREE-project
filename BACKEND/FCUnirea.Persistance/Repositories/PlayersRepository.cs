//PlayersRepository
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FCUnirea.Persistance.Repositories
{
    public class PlayersRepository : BaseRepository<Players>, IPlayersRepository
    {
        public PlayersRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext){}
        public IEnumerable<Players> GetPlayersByTeam(int teamId)
        {
            return _dbContext.Players
                .Include(p => p.Player_Teams)
                .Where(p => p.Player_TeamsId == teamId)
                .ToList();
        }

        public IEnumerable<Players> ListAllWithTeams()
        {
            return _dbContext.Players
                .Include(p => p.Player_Teams)
                .ToList();
        }

}
}
