using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodingChallengeBusiness.Entities;

namespace CodingChallengeBusiness.Interfaces
{
    /// <summary>
    /// IRepository interface for abstract data access
    /// </summary>
    /// <typeparam name="T">entity</typeparam>
    /// <typeparam name="K">identifier</typeparam>
    public interface IRepository<T, K> where T : BaseEntity
    {
        /// <summary>
        /// get all record
        /// </summary>
        /// <returns> collection of T </returns>
        List<T> GetAll();

        /// <summary>
        /// get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T : entity</returns>
        T GetById(K id);

        /// <summary>
        /// create entity 
        /// </summary>
        /// <param name="entity">entity to create</param>
        /// <returns>T :created entity</returns>
        T Create(T entity);

        /// <summary>
        /// update entity 
        /// </summary>
        /// <param name="entity">entity to update</param>
        /// <returns>T :updated entity</returns>
        T Update(T entity);

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity">entity to delete</param>
        /// <returns>bool : is deleted</returns>
        bool Delete(T entity);
        List<T> Query(Expression<Func<T, bool>> query);

        /// <summary>
        ///  query including navigation properties 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="includedProperies"></param>
        /// <returns></returns>
        List<T> QueryWithAggregations(Expression<Func<T, bool>> query,params string[] includedProperies);

    }
}