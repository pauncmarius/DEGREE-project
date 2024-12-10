using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Domain.IRepositories
{
    public interface ISeatsRepository : IBaseRepository<Seats>
    {
        IEnumerable<Seats> GetAvailableSeats(int gameId);
    }
}
