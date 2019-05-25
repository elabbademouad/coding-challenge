using CodingChallengeBusiness.Entities;
namespace CodingChallengeBusiness.Interfaces
{
    public interface IUserRepository:IRepository<User,int>
    {
        User GetUserByEmail(string email);
    }
}