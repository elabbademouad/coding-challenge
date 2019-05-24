using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodingChallengeBusiness.Interfaces;
using CodingChallengeBusiness.Entities;
using CodingChallengePersistance.Context;

namespace CodingChallengePersistance.Repositories
{
    public class UserRepository :Repository<User>, IUserRepository
    {
       public UserRepository(DataContext context):base(context){

       }
    }
}