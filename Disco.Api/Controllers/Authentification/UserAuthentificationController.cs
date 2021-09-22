using Disco.BLL.DTO;
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
        public async Task<UserDTO> Login([FromForm] LoginModel model) =>
            await serviceManager.AuthentificationService.Login(model);

        [HttpGet("log-in/facebook"), AllowAnonymous]
        public async Task<UserDTO> Facebook([FromBody] string accessToken) =>
            await serviceManager.AuthentificationService.Facebook(accessToken);

        [HttpPost("log-in/google"), AllowAnonymous]
        public async Task<IActionResult> Google([FromBody] string accessToken) =>
            Ok("Google");

        [HttpPost("log-in/apple"), AllowAnonymous]
        public async Task<IActionResult> Apple([FromBody] string accessToken) =>
            Ok("Apple");

        [HttpPost("registration"), AllowAnonymous]
        public async Task<UserDTO> Registration([FromForm] RegistrationModel model) =>
            await serviceManager.AuthentificationService.Register(model);
    }
}
