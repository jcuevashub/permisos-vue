using Core.Contracts;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Boundaries.Persistence
{
    public class BaseRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _set;


        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        IOperationResult<T> IGenericRepository<T>.Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return BasicOperationResult<T>.Ok(entity);
        }

        T IGenericRepository<T>.Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable.FirstOrDefault(predicate);
        }

        IEnumerable<T> IGenericRepository<T>.FindAll(Expression<Func<T, bool>> predicate)
            => _set.Where(predicate).ToList();

        void IGenericRepository<T>.Save()
            => _context.SaveChanges();

        IEnumerable<T> IGenericRepository<T>.Get()
            => _set.AsEnumerable();

        IOperationResult<T> IGenericRepository<T>.Remove(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            return BasicOperationResult<T>.Ok();
        }
    }
}
