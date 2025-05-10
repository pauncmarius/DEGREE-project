//SeatsRepository
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Repositories
{
    public class SeatsRepository : BaseRepository<Seats>, ISeatsRepository
    {
        public SeatsRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext)
        {

        }

        public async Task<IEnumerable<Seats>> ListAsync(Expression<Func<Seats, bool>> predicate)
        {
            return await _dbContext.Seats
                .Where(predicate)
                .ToListAsync();
        }
    }
}
