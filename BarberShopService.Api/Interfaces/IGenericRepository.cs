using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BarberShopService.Api.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T Entity);
        void UpdateAvailable(int id);
        void Delete(T entity);
        int Count();
    }
}
