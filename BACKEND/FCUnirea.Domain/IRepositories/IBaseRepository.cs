//IBaseRepository
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCUnirea.Domain.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        // Sincron
        T GetById(int id);
        IReadOnlyList<T> ListAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        // Asincron
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task SaveChangesAsync();
    }
}
