using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingChallengeBusiness.dto;
using Microsoft.AspNetCore.Authorization;
using CodingChallengeBusiness.Services;

namespace CodingChallengeAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private AuthenticationService _authService;
        public AuthenticationController(AuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody]RegisterRequest request)
        {
            return Ok(_authService.Register(request));
        }

        [HttpPost("Login")]
        public ActionResult Index([FromBody]LoginRequest request)
        {
            return Ok(_authService.LogIn(request));
        }
    }
}
