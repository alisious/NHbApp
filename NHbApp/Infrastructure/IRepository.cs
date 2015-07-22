using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NHbApp.Infrastructure
{
    public interface IRepository<T> where T :class
    {
        bool Add(T entity);
        //bool Add(IEnumerable<T> items);
        bool Update(T entity);
        bool Delete(T entity);
        //bool Delete(IEnumerable<T> entities);
        T GetById(Guid id);
        IQueryable<T> All();
        T GetBy(Expression<Func<T, bool>> expression);
        IQueryable<T> FilterBy(Expression<Func<T, bool>> expression);
    }
}
