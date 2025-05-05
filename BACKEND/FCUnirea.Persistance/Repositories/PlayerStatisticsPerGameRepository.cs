
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FCUnirea.Persistance.Repositories
{
    public class PlayerStatisticsPerGameRepository : BaseRepository<PlayerStatisticsPerGame>, IPlayerStatisticsPerGameRepository
    {
        private readonly FCUnireaDbContext _context;
        private IDbContextTransaction _transaction;

        public PlayerStatisticsPerGameRepository(FCUnireaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PlayerStatisticsPerGame>> GetScorersByGameAsync(int gameId)
        {
            return await _dbContext.PlayerStatisticsPerGame
                .Include(p => p.PlayerStatisticsPerGame_Players)
                .ThenInclude(p => p.Player_Teams)
                .Where(p => p.PlayerStatisticsPerGame_GamesId == gameId && p.Goals > 0)
                .ToListAsync();
        }
    }

}
