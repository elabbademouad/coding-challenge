using CodingChallengeBusiness.Entities;
namespace CodingChallengeBusiness.Interfaces
{
    /// <summary>
    /// User repository interface
    /// </summary>
    /// <typeparam name="User"></typeparam>
    /// <typeparam name="int"></typeparam>
    public interface IUserRepository : IRepository<User, int>
    {
        User GetUserByEmail(string email);
    }
}