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
        /// <summary>
        /// get user by email
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns></returns>
        User GetUserByEmail(string email);
    }
}