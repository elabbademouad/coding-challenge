namespace CodingChallengeBusiness.Interfaces
{
    public interface IUnitOfWork
    {
         IUserRepository UserRepository { get;}
         IShopRepository ShopRepository { get;}
         IUserShopPreferenceRepository UserShopPreferenceRepository { get;}
    }

}