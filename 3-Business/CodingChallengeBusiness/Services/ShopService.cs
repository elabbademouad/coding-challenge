using System.Collections.Generic;
using CodingChallengeBusiness.Entities;
using CodingChallengeBusiness.Interfaces;
using System.Linq;
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
            List<Shop> shops = null;
            var user = _uow.UserRepository.GetById(userId);
            var preferredShops = GetPreferredShops(user.Id);
            // exclude preferred shops
            if (preferredShops == null)
            {
                shops = _uow.ShopRepository.GetAll();
            }
            else
            {
                shops = _uow.ShopRepository.Query((s) => !preferredShops.Exists(p => p.Id == s.Id));
            }
            // order by distance
            var nearbyShops = shops.OrderBy((s) => _mapUtility.CalculateDistance(s.Position, user.Position)).ToList();
            return nearbyShops;
        }

        /// <summary>
        /// Get preferred shops by user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Shops list</returns>
        public List<Shop> GetPreferredShops(int userId)
        {
            return _uow.UserShopPreferenceRepository.GetPreferredShops(userId);
        }
    }
}