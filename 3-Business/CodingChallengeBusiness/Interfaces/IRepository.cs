using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace CodingChallengeBusiness.Interfaces
{
    /// <summary>
    /// IRepository interface for abstract data access
    /// </summary>
    /// <typeparam name="T">entity</typeparam>
    /// <typeparam name="K">identifier</typeparam>
    public interface IRepository<T, K>
    {
        List<T> GetAll();
        T GetById(K id);
        void Create(T entity);
        void Update(T entity);
        bool Delete(T entity);
        List<T> Query(Expression<Func<T, bool>> query);
    }
}