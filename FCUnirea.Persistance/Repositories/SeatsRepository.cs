using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Persistance.Repositories
{
    public class SeatsRepository : BaseRepository<Seats>, ISeatsRepository
    {
        public SeatsRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext)
        {

        }

        IEnumerable<Seats> ISeatsRepository.GetAvailableSeats(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
