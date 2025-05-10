//TicketsRepository
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Repositories
{
    public class TicketsRepository : BaseRepository<Tickets>, ITicketsRepository
    {
        public TicketsRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext)
        {

        }

        public async Task<IEnumerable<Tickets>> GetTicketsByUserIdAsync(int userId)
        {
            return await _dbContext.Tickets
                .Include(t => t.Ticket_Games).ThenInclude(g => g.Game_HomeTeam)
                .Include(t => t.Ticket_Games).ThenInclude(g => g.Game_AwayTeam)
                .Include(t => t.Ticket_Games).ThenInclude(g => g.Game_Competitions)
                .Include(t => t.Ticket_Games).ThenInclude(g => g.Game_Stadiums)
                .Include(t => t.Ticket_Seats)
                .Where(t => t.Ticket_UsersId == userId)
                .ToListAsync();
        }

    }
}
