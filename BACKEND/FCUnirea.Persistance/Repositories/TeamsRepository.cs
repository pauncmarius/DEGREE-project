//TeamsRepository
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Repositories
{
    public class TeamsRepository : BaseRepository<Teams>, ITeamsRepository
    {
        public TeamsRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext)
        {
        }
        public async Task<IEnumerable<Teams>> GetInternalTeamsAsync()
        {
            return await _dbContext.Teams
                .Where(t => t.IsInternal)
                .ToListAsync();
        }
    }
}
