using CodingChallengeBusiness.Enums;

namespace CodingChallengeAPI.Model
{
    public class UserShopPrefernceRequest
    {
        public int ShopId {get;set;}
        public ShopStatus Status {get;set;}
    }
}