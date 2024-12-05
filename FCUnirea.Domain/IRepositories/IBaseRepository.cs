using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Domain.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);

        IReadOnlyList<T> ListAll();

        T Add(T Entity);

        void Update(T Entity);

        void Delete(T Entity);
    }
}
