
using System.Collections.Generic;
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface IPlayersRepository : IBaseRepository<Players>
    {
        IEnumerable<Players> GetPlayersByTeam(int teamId); // 👈 nou

    }
}
