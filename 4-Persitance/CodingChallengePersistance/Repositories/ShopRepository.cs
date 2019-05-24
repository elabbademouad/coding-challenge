using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodingChallengeBusiness.Interfaces;
using CodingChallengeBusiness.Entities;
using CodingChallengePersistance.Context;

namespace CodingChallengePersistance.Repositories
{
    public class ShopRepository :Repository<User>, IShopRepository
    {
       public ShopRepository(DataContext context):base(context){

       }
    }
}