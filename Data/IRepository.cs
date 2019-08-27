using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AllInOne.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetQuery();

        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> where);
        T Single(Expression<Func<T, bool>> where);
        T First(Expression<Func<T, bool>> where);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}