using CodingChallengeBusiness.Entities;
using CodingChallengeBusiness.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace CodingChallengeBusiness.Interfaces
{
    /// <summary>
    /// UserShopPreference repository interface
    /// </summary>
    /// <typeparam name="UserShopPreference"></typeparam>
    /// <typeparam name="int"></typeparam>
    public interface IUserShopPreferenceRepository : IRepository<UserShopPreference, int>
    {
        /// <summary>
        /// Get  shops by user and status 
        /// </summary>
        /// <param name="userId">user identifyer</param>
        /// <param name="status">shop status enum</param>
        /// <returns>Shops list</returns>
        List<Shop> GetShopsByStatus(int userId,ShopStatus status);
    }
}