using Disco.BLL.Constants;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.Authentication;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [Route("api/admin/users")]
    [ApiController]
    [Authorize(
         AuthenticationSchemes = AuthScheme.UserToken,
         Roles = "Admin")]
    public class AdminUserController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public AdminUserController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RegistrationModel model) =>
            await serviceManager.AdminUserService.CreateUserAsync(model);

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove([FromRoute] int id) =>
            await serviceManager.AdminUserService.RemoveUserAsync(id);

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll() =>
            await serviceManager.AdminUserService.GetAllUsers(1, 10);
    }
}
