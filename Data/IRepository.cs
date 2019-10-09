using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AllInOne.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetQuery();

        // IEnumerable<T> Get();
        Task<IEnumerable<T>> GetAsync();
        // IEnumerable<T> Get(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> where);
        // T Single(Expression<Func<T, bool>> where);
        Task<T> SingleAsync(Expression<Func<T, bool>> where);
        // T First(Expression<Func<T, bool>> where);
        Task<T> FirstAsync(Expression<Func<T, bool>> where);

        // void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}