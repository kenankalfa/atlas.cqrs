using System;
using System.Linq;
using System.Linq.Expressions;

namespace Atlas.Storage
{
    public interface IReportingRepository<T>
    {
        IQueryable<T> List(Expression<Func<T, bool>> predicate = null);
        int Count(Expression<Func<T, bool>> predicate = null);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
        T Get(Guid itemRef);
    }
}
