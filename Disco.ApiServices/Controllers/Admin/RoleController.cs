using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Roles;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers.Admin
{
    [Route("api/admin/roles")]
    [Authorize(
        AuthenticationSchemes = AuthSchema.UserToken, 
        Roles = UserRole.Admin)]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("create"), AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            var role = await _roleService.CreateRoleAsync(dto);

            return Ok(role);
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetAllRoles([FromQuery] GetAllRolesDto dto)
        {
            return await _roleService.GetAllRoles(new GetAllRolesDto { PageNumber = 1, PageSize = 10});
        }
    }
}
