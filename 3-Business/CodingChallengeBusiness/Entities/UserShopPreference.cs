using CodingChallengeBusiness.Enums;

namespace CodingChallengeBusiness.Entities
{
    public class  UserShopPreference : BaseEntity
    {
       public User User { get; set; }          
       public Shop Shop { get; set; }  
       public ShopStatus Status {get;set;}        
    }
}