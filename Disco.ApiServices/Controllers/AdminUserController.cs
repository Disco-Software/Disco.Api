using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Authentication;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Disco.Business.Validators;

namespace Disco.ApiServices.Controllers
{
    [Route("api/admin/users")]
    [ApiController]
    [Authorize(
         AuthenticationSchemes = AuthScheme.UserToken,
         Roles = "Admin")]
    public class AdminUserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAdminUserService _adminUserService;

        public AdminUserController(
            UserManager<User> userManager,
            IAdminUserService adminUserService)
        {
            this._userManager = userManager;
            this._adminUserService = adminUserService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RegistrationDto model)
        {
            var validator = await RegistrationValidator
                .Create(_userManager)
                .ValidateAsync(model);

            if (validator.Errors.Count > 0)
                return BadRequest(validator.Errors);

           var user = await _adminUserService.CreateUserAsync(model);

            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            await _adminUserService.RemoveUserAsync(id);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return await _adminUserService.GetAllUsers(1, 10);
        }
    }
}
