using CodingChallengeBusiness.Entities;
namespace CodingChallengeBusiness.dto
{
    public class AuthenticationResponse
    {
        public string Message { get; set; }
        public bool IsSuccess {get;set;}
        public User User { get; set; }
    }
}