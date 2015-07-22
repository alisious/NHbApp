using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace NHbApp.Infrastructure
{
    public class Repository<T> :IRepository<T> where T :class
    {
        
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }
        
        public bool Add(T entity)
        {
            _session.Save(entity);
            _session.Flush();
            return true;
        }

        public bool Update(T entity)
        {
            _session.Update(entity);
            _session.Flush();
            return true;
        }

        public bool Delete(T entity)
        {
            _session.Delete(entity);
            _session.Flush();
            return true;
        }

        public T GetById(Guid id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> All()
        {
            return _session.Query<T>();
        }

        public T GetBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).FirstOrDefault();
        }

        public IQueryable<T> FilterBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }
    }
}
