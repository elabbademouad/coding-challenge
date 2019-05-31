using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodingChallengeBusiness.Interfaces;
using CodingChallengePersistance.Context;
using System.Linq;
using CodingChallengeBusiness.Entities;
using Microsoft.EntityFrameworkCore;


namespace CodingChallengePersistance.Repositories
{
    /// <summary>
    /// Repository implementation
    /// </summary>
    /// <typeparam name="T">entity</typeparam>
    public class Repository<T> : IRepository<T, int> where T : BaseEntity
    {
        private DataContext _context;
        public Repository(DataContext Context)
        {
            _context = Context;
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }
        public T Create(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            var entityInserted = _context.Set<T>().Add(entity);
            if (_context.SaveChanges() == 1)
            {
                return entityInserted.Entity;
            }
            else
            {
                return null;
            }
        }
        public T Update(T entity)
        {
            _context.Attach(entity);
            entity.UpdatedDate = DateTime.Now;
            if (_context.SaveChanges() == 1)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }
        public bool Delete(T entity)
        {
            _context.Attach(entity);
            _context.Remove(entity);
            return _context.SaveChanges() == 1;
        }
        public List<T> Query(Expression<Func<T, bool>> query)
        {
            return _context.Set<T>().Where(query).ToList();
        }

        public List<T> QueryWithAggregations(Expression<Func<T, bool>> query,params string[] includedProperies)
        {
            
            IQueryable<T> queryResult=_context.Set<T>();
            foreach (var property in includedProperies)
            {
                queryResult=queryResult.Include(property);
            }
            return queryResult.Where(query).ToList();
        }
    }
}