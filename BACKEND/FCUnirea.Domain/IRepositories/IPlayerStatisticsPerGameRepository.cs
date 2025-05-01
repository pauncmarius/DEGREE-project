using FCUnirea.Domain.Entities;
using System.Threading.Tasks;

namespace FCUnirea.Domain.IRepositories
{
    public interface IPlayerStatisticsPerGameRepository : IBaseRepository<PlayerStatisticsPerGame>
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
