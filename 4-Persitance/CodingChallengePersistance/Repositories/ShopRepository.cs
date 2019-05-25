using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodingChallengeBusiness.Interfaces;
using CodingChallengeBusiness.Entities;
using CodingChallengePersistance.Context;

namespace CodingChallengePersistance.Repositories
{
    /// <summary>
    /// implementation of IShopRepository
    /// </summary>
    /// <typeparam name="Shop"></typeparam>
    public class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(DataContext context) : base(context)
        {

        }
    }
}