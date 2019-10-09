using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AllInOne.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<T> GetQuery()
        {
            return _unitOfWork.Context.Set<T>().AsQueryable();
        }

        public IEnumerable<T> Get()
        {
            return _unitOfWork.Context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _unitOfWork.Context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            return _unitOfWork.Context.Set<T>().Where(where).ToList();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> where)
        {
            return await _unitOfWork.Context.Set<T>().Where(where).ToListAsync();
        }

        public T Single(Expression<Func<T, bool>> where)
        {
            return _unitOfWork.Context.Set<T>().SingleOrDefault(where);
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> where)
        {
            return await _unitOfWork.Context.Set<T>().SingleOrDefaultAsync(where);
        }

        public T First(Expression<Func<T, bool>> where)
        {
            return _unitOfWork.Context.Set<T>().FirstOrDefault(where);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> where)
        {
            return await _unitOfWork.Context.Set<T>().FirstOrDefaultAsync(where);
        }

        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _unitOfWork.Context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _unitOfWork.Context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}