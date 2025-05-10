//IPlayerStatisticsPerGameRepository
using FCUnirea.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FCUnirea.Domain.IRepositories
{
    public interface IPlayerStatisticsPerGameRepository : IBaseRepository<PlayerStatisticsPerGame>
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        Task<IEnumerable<PlayerStatisticsPerGame>> GetScorersByGameAsync(int gameId);
    }
}
