
using System.Collections.Generic;
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface IGamesRepository : IBaseRepository<Games>
    {
        IEnumerable<Games> GetGamesByTeam(int teamId); // 👈 nou

    }
}
