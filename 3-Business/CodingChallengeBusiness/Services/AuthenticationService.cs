using CodingChallengeBusiness.Interfaces;
using CodingChallengeBusiness.dto;
using CodingChallengeBusiness.Entities;
using System.Linq;
using CodingChallengeBusiness.Constants;

namespace CodingChallengeBusiness.Services
{
    /// <summary>
    /// authentication services
    /// </summary>
    public class AuthenticationService
    {
        private IUnitOfWork _uow;
        public AuthenticationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// Registration 
        /// </summary>
        /// <param name="request">registration informations</param>
        /// <returns>response</returns>
        public AuthenticationResponse Register(RegisterRequest request)
        {
            AuthenticationResponse response = new AuthenticationResponse();
            if (IsEmailAlreadyExists(request.Email))
            {
                response.Message = Messages.EmailAlreadyUsed;
                response.IsSuccess = false;
                response.User = null;
                return response;
            }
            else
            {
                var user = _uow.UserRepository.Create(new User()
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Password = request.Password,
                    Position = request.Position
                });
                response.Message = Messages.RegisterWithSuccess;
                response.User = user;
                response.IsSuccess = true;
                return response;
            }
        }

        /// <summary>
        ///  Login for authentication
        /// </summary>
        /// <param name="request">Login informations</param>
        /// <returns >response </returns>
        public AuthenticationResponse LogIn(LoginRequest request)
        {
            var user = _uow.UserRepository.Query(u => u.Email == request.Email && u.Password == request.Password).FirstOrDefault();
            var response = new AuthenticationResponse();
            if (user == null)
            {
                response.Message = Messages.InvalidAuthentication;
                response.IsSuccess = false;
            }
            else
            {
                response.User = user;
                response.Message = Messages.LoginWithSuccess;
                response.IsSuccess = true;
            }
            return response;
        }

        /// <summary>
        /// check if email exists
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>bool</returns>
        private bool IsEmailAlreadyExists(string email)
        {
            var user = _uow.UserRepository.GetUserByEmail(email);
            return user != null;
        }
    }
}