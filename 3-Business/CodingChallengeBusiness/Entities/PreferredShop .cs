namespace CodingChallengeBusiness.Entities
{
    public class  PreferredShop : BaseEntity
    {
       public User User { get; set; }          
       public Shop Shop { get; set; }          
    }
}