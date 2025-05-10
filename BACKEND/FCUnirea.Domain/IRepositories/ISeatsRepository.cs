//ISeatsRepository
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface ISeatsRepository : IBaseRepository<Seats>
    {
        Task<IEnumerable<Seats>> ListAsync(Expression<Func<Seats, bool>> predicate);

    }
}
