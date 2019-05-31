using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingChallengeBusiness.dto;
using Microsoft.AspNetCore.Authorization;
using CodingChallengeBusiness.Services;
using System.Security.Claims;
using CodingChallengeBusiness.Enums;
using CodingChallengeAPI.Model;

namespace CodingChallengeAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private ShopService _shopService;
        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("NearbyShops")]
        public ActionResult NearbyShops()
        {
            var userId = GetCurrentUserId();
            return Ok(_shopService.GetNearbyShops(userId));
        }

        [HttpGet("PreferredShops")]
        public ActionResult PreferredShops()
        {
            var userId = GetCurrentUserId();
            return Ok(_shopService.GetPreferredShops(userId));
        }

        [HttpPost("LikeOrDislike")]
        public ActionResult LikeOrDislike([FromBody] UserShopPrefernceRequest resuest)
        {
            var userId = GetCurrentUserId();
            return Ok(_shopService.LikeOrDislikeShop(resuest.ShopId,resuest.Status,userId));
        }

        [HttpPost("RemoveShopfromPreferred")]
        public ActionResult RemoveShopfromPreferred([FromBody] int shopId)
        {
            var userId = GetCurrentUserId();
            return Ok(_shopService.RemoveShopfromPreferred(shopId,userId));
        }

        /// <summary>
        /// get current user identifier
        /// </summary>
        /// <returns>int </returns>
        private int GetCurrentUserId()
        {
            return int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

    }
}
