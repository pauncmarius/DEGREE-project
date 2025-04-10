
using System.Collections.Generic;
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface ICommentsRepository : IBaseRepository<Comments>
    {
        IEnumerable<Comments> GetByNewsIdWithUser(int newsId);

    }
}
