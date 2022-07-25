using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Roles;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [Route("api/admin/roles")]
    [Authorize(
        AuthenticationSchemes = AuthScheme.UserToken, 
        Roles = "Admin")]
    [ApiController]
    public class AdminRoleController : ControllerBase
    {
        private readonly IAdminRoleService adminRoleService;

        public AdminRoleController(IAdminRoleService _adminRoleService)
        {
            this.adminRoleService = _adminRoleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto model)
        {
            var role = await adminRoleService.CreateRoleAsync(model);

            return Ok(role);
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetAllRoles([FromQuery] GetAllRolesDto dto)
        {
            return await adminRoleService.GetAllRoles(new GetAllRolesDto { PageNumber = 1, PageSize = 10});
        }
    }
}
