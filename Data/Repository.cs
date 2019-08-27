using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace AllInOne.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UnitOfWork _unitOfWork;

        public Repository(UnitOfWork unitOfWork)
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

        public IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            return _unitOfWork.Context.Set<T>().Where(where).ToList();
        }

        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            var existing = _unitOfWork.Context.Set<T>().Find(entity);
            if (existing != null)
                _unitOfWork.Context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public T Single(Expression<Func<T, bool>> where)
        {
            return _unitOfWork.Context.Set<T>().SingleOrDefault(where);
        }

        public T First(Expression<Func<T, bool>> where)
        {
            return _unitOfWork.Context.Set<T>().FirstOrDefault(where);
        }
    }
}