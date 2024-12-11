using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Persistance.Repositories
{
    public interface SeatsRepository : BaseRepository<Seats>
    {
        IEnumerable<Seats> GetAvailableSeats(int gameId);
    }
}
