using Disco.BLL.Constants;
using Disco.BLL.Interfaces;
using Disco.BLL.Dto.Authentication;
using Disco.DAL.Models;
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
        private readonly IAdminUserService adminUserService;

        public AdminUserController(IAdminUserService adminUserService)
        {
            this.adminUserService = adminUserService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RegistrationDto model)
        {
            return await adminUserService.CreateUserAsync(model);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
           return await adminUserService.RemoveUserAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return await adminUserService.GetAllUsers(1, 10);
        }
    }
}
