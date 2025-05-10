//INewsRepository
using FCUnirea.Domain.Entities;

namespace FCUnirea.Domain.IRepositories
{
    public interface INewsRepository : IBaseRepository<News>
    {
        public News GetByIdWithAuthor(int id);
    }
}
