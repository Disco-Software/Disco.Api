using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Role.RequestHandlers.GetRoles;
using Disco.Business.Interfaces.Dtos.Roles.Admin.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Role
{
    [Route("api/admin/roles")]
    public class RoleController : AdminController
    {
        private readonly IMediator _mediator;

        public RoleController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<GetRolesResponseDto>> GetAllRoles([FromQuery] GetRolesRequestDto dto) =>
            await _mediator.Send(new GetRolesRequest(dto));
    }
}
