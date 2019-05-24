using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodingChallengeBusiness.Interfaces;
using CodingChallengePersistance.Context;
using System.Linq;
namespace CodingChallengePersistance.Repositories
{
    public class Repository<T> : IRepository<T, int> where T : class, IBaseEntity
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
            return _context.Set<T>().FirstOrDefault();
        }
        public void Create(T entity)
        {
            entity.CreatedDate=DateTime.Now;
            entity.UpdatedDate=DateTime.Now;
            _context.Set<T>().Add(entity);    
            _context.SaveChanges();          
        }
        public void Update(T entity)
        {
            _context.Attach(entity);
            entity.UpdatedDate=DateTime.Now;
            _context.SaveChanges();          
        }
        public bool Delete(T entity)
        {
            _context.Attach(entity);
            _context.Remove(entity);
            return _context.SaveChanges()==1;
        }
        public List<T> Query(Expression<Func<T, bool>> query)
        {
            return _context.Set<T>().Where(query).ToList();
        }
    }
}