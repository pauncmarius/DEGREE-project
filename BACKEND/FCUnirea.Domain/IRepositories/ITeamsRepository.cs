//ITeamsRepository
using System.Collections.Generic;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface ITeamsRepository : IBaseRepository<Teams>
    {
        Task<IEnumerable<Teams>> GetInternalTeamsAsync();

    }
}
