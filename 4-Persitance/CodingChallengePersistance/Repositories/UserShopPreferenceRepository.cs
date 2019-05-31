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


        public List<Shop> GetShopsByStatus(int userId,ShopStatus status)
        {
            var result = QueryWithAggregations(
                (o) => o.User.Id == userId && o.Status == status,
                "User","Shop")
                ?.Select(r => r.Shop)
                ?.ToList();
            return result;
        }
    }
}