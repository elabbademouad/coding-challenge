using CodingChallengeBusiness.Entities;
using System.Collections.Generic;
namespace CodingChallengeBusiness.Interfaces
{
    /// <summary>
    /// UserShopPreference repository interface
    /// </summary>
    /// <typeparam name="UserShopPreference"></typeparam>
    /// <typeparam name="int"></typeparam>
    public interface IUserShopPreferenceRepository : IRepository<UserShopPreference, int>
    {
        List<Shop> GetPreferredShops(int userId);
    }
}