using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Controllers.Authentification
{
    [ApiController]
    [Route("api/user/authentification")]
    public class UserAuthentificationController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public UserAuthentificationController(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;

        [HttpPost("log-in"), AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            var user = await serviceManager.AuthentificationService.Login(model);
            return Ok(user);
        }

        [HttpPost("log-in/facebook"), AllowAnonymous]
        public async Task<IActionResult> Facebook([FromBody] string accessToken)
        {
            var user = await serviceManager.AuthentificationService.Facebook(accessToken);
            return Ok(user);
        }

        [HttpPost("log-in/google"), AllowAnonymous]
        public async Task<IActionResult> Google([FromBody] string accessToken)
        {
             throw new NotImplementedException("Google is not impplimented");
        }

        [HttpPost("log-in/apple"), AllowAnonymous]
        public async Task<IActionResult> Apple([FromBody] string accessToken)
        {
            throw new NotImplementedException("Apple is not implimented");
        }

        [HttpPost("registration"), AllowAnonymous]
        public async Task<IActionResult> Registration([FromForm] RegistrationModel model)
        {
            var user = await serviceManager.AuthentificationService.Register(model);
            return Ok(user);
        }
    }
}
