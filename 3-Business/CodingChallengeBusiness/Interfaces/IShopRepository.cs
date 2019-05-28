using CodingChallengeBusiness.Entities;
using System.Collections.Generic;
namespace CodingChallengeBusiness.Interfaces
{
    /// <summary>
    ///  Shop repository interface
    /// </summary>
    /// <typeparam name="Shop">User</typeparam>
    /// <typeparam name="int">int</typeparam>
    public interface IShopRepository : IRepository<Shop, int>
    {

    }
}