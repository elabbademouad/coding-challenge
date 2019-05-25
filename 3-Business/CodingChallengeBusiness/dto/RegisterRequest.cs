using CodingChallengeBusiness.Entities;
namespace CodingChallengeBusiness.dto
{
    public class RegisterRequest
    {
        public string FirstName {get;set;}

        public string LastName {get;set;}

        public string Email {get;set;}

        public string Password {get;set;}

        public string Position {get;set;}
    }
}