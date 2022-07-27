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
        private readonly IAdminRoleService _adminRoleService;

        public AdminRoleController(IAdminRoleService adminRoleService)
        {
            _adminRoleService = adminRoleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto model)
        {
            var role = await _adminRoleService.CreateRoleAsync(model);

            return Ok(role);
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetAllRoles([FromQuery] GetAllRolesDto dto)
        {
            return await _adminRoleService.GetAllRoles(new GetAllRolesDto { PageNumber = 1, PageSize = 10});
        }
    }
}
