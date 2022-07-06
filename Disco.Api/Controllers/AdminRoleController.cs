using Disco.BLL.Constants;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
