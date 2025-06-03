//ITicketsRepository
using System.Collections.Generic;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface ITicketsRepository : IBaseRepository<Tickets>
    {
        Task<IEnumerable<Tickets>> GetTicketsByUserIdAsync(int userId);
        Task<IEnumerable<Tickets>> GetTicketsByGameIdAsync(int gameId);

    }
}
