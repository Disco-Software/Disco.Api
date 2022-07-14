using Disco.BLL.Constants;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.Roles;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [Route("api/admin/roles")]
    [Authorize(
        AuthenticationSchemes = AuthScheme.UserToken, 
        Roles = "Admin")]
    [ApiController]
    public class AdminRoleController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public AdminRoleController(IServiceManager _serviceManager)
        {
            this.serviceManager = _serviceManager;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRoleModel model) =>
            await serviceManager.RoleService.CreateRoleAsync(model);

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetAllRoles() => 
            await serviceManager.RoleService.GetAllRoles(new GetAllRolesModel { PageNumber = 1, PageSize = 10});  
    }
}
