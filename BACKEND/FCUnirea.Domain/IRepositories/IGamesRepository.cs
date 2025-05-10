//IGamesRepository
using System.Collections.Generic;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface IGamesRepository : IBaseRepository<Games>
    {
        IEnumerable<Games> GetGamesByTeam(int teamId);
        Task<IEnumerable<Teams>> GetTeamsAsync();

        IEnumerable<Games> GetAvailableHomeGames();

        Task<Games?> GetGameWithDetailsAsync(int id);

        Task<Games> GetByIdWithStadiumAsync(int gameId);


    }
}
