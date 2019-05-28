using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodingChallengeBusiness.Interfaces;
using CodingChallengeBusiness.Entities;
using CodingChallengeBusiness.Enums;
using CodingChallengePersistance.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CodingChallengePersistance.Repositories
{
    public class UserShopPreferenceRepository : Repository<UserShopPreference>, IUserShopPreferenceRepository
    {
        private DataContext _dataContext;
        public UserShopPreferenceRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }

        /// <summary>
        ///  get preferred shops by user id
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>shops</returns>
        public List<Shop> GetPreferredShops(int userId)
        {
            var result = _dataContext.UserShopPreferences.Include(s => s.Shop)
                                            .Include(u => u.User)
                                            .Where(o => o.User.Id == userId && o.Status == ShopStatus.Liked)
                                            .Select(r => r.Shop).ToList();
            return result;
        }
    }
}