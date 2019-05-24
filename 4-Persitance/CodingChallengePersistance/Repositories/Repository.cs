using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodingChallengeBusiness.Interfaces;
using CodingChallengePersistance.Context;
namespace CodingChallengePersistance.Repositories
{
    public class Repository<T> : IRepository<T, int> where T : IBaseEntity
    {
        private DataContext _context;
        public Repository(DataContext Context)
        {           
            _context = Context;
        }
        public List<T> GetAll()
        {
            throw new  NotImplementedException();
        }
        public T GetById(int id)
        {
            throw new  NotImplementedException();
        }
        public void Create(T entity)
        {
            throw new  NotImplementedException();            
        }
        public void Update(T entity)
        {
            throw new  NotImplementedException();            
        }
        public bool Delete(T entity)
        {
            throw new  NotImplementedException();
        }
        public List<T> Query(Expression<Func<T, bool>> query)
        {
            throw new  NotImplementedException();
        }
    }
}