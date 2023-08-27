using Disco.ApiServices.Features.Role.RequestHandlers.CreateRole;
using Disco.ApiServices.Features.Role.RequestHandlers.GetRoles;
using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Roles;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Role
{
    [Route("api/admin/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMediator _mediator;

        public RoleController(
            IRoleService roleService,
            IMediator mediator)
        {
            _mediator = mediator;
            _roleService = roleService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Domain.Models.Models.Role>> Create([FromBody] CreateRoleDto dto) =>
            await _mediator.Send(new CreateRoleRequest(dto));


        [HttpGet]
        public async Task<ActionResult<List<Domain.Models.Models.Role>>> GetAllRoles([FromQuery] GetAllRolesDto dto) =>
            await _mediator.Send(new GetRolesRequest(dto));
    }
}
