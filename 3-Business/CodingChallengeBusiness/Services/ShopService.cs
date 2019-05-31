using System.Collections.Generic;
using CodingChallengeBusiness.Entities;
using CodingChallengeBusiness.Interfaces;
using CodingChallengeBusiness.Enums;
using System.Linq;
using System;
namespace CodingChallengeBusiness.Services
{
    public class ShopService
    {
        private IUnitOfWork _uow;
        private IMapUtility _mapUtility;

        /// <summary>
        ///  constructor
        /// </summary>
        /// <param name="uow">unit of owrk</param>
        /// <param name="mapUtility">map utility</param>
        public ShopService(IUnitOfWork uow, IMapUtility mapUtility)
        {
            _uow = uow;
            _mapUtility = mapUtility;
        }

        /// <summary>
        /// Get nearby shops by user
        /// </summary>
        /// <param name="userId">int</param>
        /// <returns>shops</returns>
        public List<Shop> GetNearbyShops(int userId)
        {
            List<Shop> shops = _uow.ShopRepository.GetAll();
            var user = _uow.UserRepository.GetById(userId);
            var preferredShops = GetPreferredShops(user.Id);

            //get shops unliked less then 2 hours
            var unlikedShops = _uow.UserShopPreferenceRepository.QueryWithAggregations(
                (o) => o.User.Id == userId && o.Status == ShopStatus.Unliked && (DateTime.Now - o.UpdatedDate).TotalHours < 2, "Shop", "User")
                ?.Select(o => o.Shop)
                ?.ToList();

            // exclude preferred shops
            if (preferredShops != null)
            {
                shops = shops.Where((s) => !preferredShops.Exists(p => p.Id == s.Id))
                              ?.ToList();
            }

            // exclude shops unliked  less then 2 hours
            if (unlikedShops != null)
            {
                shops = shops.Where((s) => !unlikedShops.Exists(p => p.Id == s.Id))
                             ?.ToList();
            }

            // order by distance
            var nearbyShops = shops.OrderBy((s) => _mapUtility.CalculateDistance(s.Position, user.Position))
                                   .ToList();
            return nearbyShops;
        }

        /// <summary>
        /// Get preferred shops by user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Shops list</returns>
        public List<Shop> GetPreferredShops(int userId)
        {
            return _uow.UserShopPreferenceRepository.GetShopsByStatus(userId, ShopStatus.Liked);
        }


        /// <summary>
        /// Like or dislike shop 
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <param name="status">status</param>
        /// <returns>Shops list</returns>
        public bool LikeOrDislikeShop(int shopId, ShopStatus status, int userId)
        {
            var userShop = _uow.UserShopPreferenceRepository.QueryWithAggregations((o) => o.User.Id == userId && o.Shop.Id == shopId, "User", "Shop").FirstOrDefault();
            if (userShop != null)
            {
                userShop.Status = status;
                return _uow.UserShopPreferenceRepository.Update(userShop) != null;
            }
            else
            {
                var shop = _uow.ShopRepository.GetById(shopId);
                var user = _uow.UserRepository.GetById(userId);
                if (shop == null || shop == null)
                {
                    return false;
                }
                var newEntity = new UserShopPreference()
                {
                    Shop = _uow.ShopRepository.GetById(shopId),
                    User = _uow.UserRepository.GetById(userId),
                    Status = status
                };
                return _uow.UserShopPreferenceRepository.Create(newEntity) != null;
            }
        }

        /// <summary>
        /// remove shop from preferred
        /// </summary>
        /// <param name="shopId">shop identifier</param>
        /// <param name="userId">user identifier</param>
        /// <returns></returns>
        public bool RemoveShopfromPreferred(int shopId, int userId)
        {
            var userShopPreference = _uow.UserShopPreferenceRepository
            .QueryWithAggregations(o => o.Status == ShopStatus.Liked
                                                && o.User.Id == userId
                                                && o.Shop.Id == shopId
                                    , "Shop", "User")
                                    ?.FirstOrDefault();
            if (userShopPreference == null)
            {
                return false;
            }
            else
            {
                return _uow.UserShopPreferenceRepository.Delete(userShopPreference);
            }
        }
    }
}