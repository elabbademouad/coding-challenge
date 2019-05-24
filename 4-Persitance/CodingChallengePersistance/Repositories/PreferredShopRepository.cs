using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodingChallengeBusiness.Interfaces;
using CodingChallengeBusiness.Entities;
using CodingChallengePersistance.Context;

namespace CodingChallengePersistance.Repositories
{
    public class PreferredShopRepository :Repository<User>, IPreferredShopRepository
    {
       public PreferredShopRepository(DataContext context):base(context){

       }
    }
}