namespace CodingChallengeBusiness.Interfaces
{
    /// <summary>
    /// Unit of work interface
    /// </summary>
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IShopRepository ShopRepository { get; }
        IUserShopPreferenceRepository UserShopPreferenceRepository { get; }
    }

}