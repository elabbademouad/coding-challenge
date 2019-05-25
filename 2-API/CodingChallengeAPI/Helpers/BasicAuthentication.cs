using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CodingChallengeBusiness.Constants;
using CodingChallengeBusiness.dto;
using CodingChallengeBusiness.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Business=CodingChallengeBusiness.Services;

namespace CodingChallengeAPI.Helpers
{
    /// <summary>
    ///  implementation of basic authentication
    /// </summary>
    /// <typeparam name="AuthenticationSchemeOptions"></typeparam>
    public class BasicAuthentication : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly Business.AuthenticationService _authenticationService;

        public BasicAuthentication(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            Business.AuthenticationService authenticationService)
            : base(options, logger, encoder, clock)
        {
            _authenticationService = authenticationService;
        }

        protected override  Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.Fail(Messages.MissingHeader));

            AuthenticationResponse response = null;
            try 
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var request=new LoginRequest();
                request.Email=credentials[0];
                request.Password=credentials[1];
                response =  _authenticationService.LogIn(request);
                if(!response.IsSuccess)
                {
                    return Task.FromResult(AuthenticateResult.Fail(response.Message));
                }
            } 
            catch 
            {
                return Task.FromResult(AuthenticateResult.Fail(Messages.InvalidHeader));
            }
            var claims = new[] { 
                new Claim(ClaimTypes.NameIdentifier,response.User.Id.ToString()),
                new Claim(ClaimTypes.Name, response.User.Email)
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}