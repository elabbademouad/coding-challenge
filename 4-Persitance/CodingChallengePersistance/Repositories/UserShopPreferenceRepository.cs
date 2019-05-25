using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodingChallengeBusiness.Interfaces;
using CodingChallengeBusiness.Entities;
using CodingChallengePersistance.Context;

namespace CodingChallengePersistance.Repositories
{
    public class UserShopPreferenceRepository : Repository<UserShopPreference>, IUserShopPreferenceRepository
    {
        public UserShopPreferenceRepository(DataContext context) : base(context)
        {

        }
    }
}