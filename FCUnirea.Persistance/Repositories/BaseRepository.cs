using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace FCUnirea.Persistance.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly FCUnireaDbContext _dbContext;

        public BaseRepository(FCUnireaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IReadOnlyList<T> ListAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Add(T Entity)
        {
            _dbContext.Set<T>().Add(Entity);
            _dbContext.SaveChanges();
            return Entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChangesAsync();
        }

        public void Delete(T Entity)
        {
            _dbContext.Set<T>().Remove(Entity);
            _dbContext.SaveChanges();
        }
    }
}
