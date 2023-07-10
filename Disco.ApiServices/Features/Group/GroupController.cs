using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Chat;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disco.ApiServices.Controllers;
using MediatR;
using Disco.ApiServices.Features.Group.RequestHandlers.CreateGroup;
using Disco.ApiServices.Features.Group.RequestHandlers.GetAll;
using Disco.ApiServices.Features.Group.RequestHandlers.DeleteGroup;

namespace Disco.ApiServices.Features.Group
{
    [Route("api/user/groups")]
    public class GroupController : UserController
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Domain.Models.Models.Group>> CreateAsync([FromBody] CreateGroupRequestDto dto) =>
            await _mediator.Send(new CreateGroupRequest(dto));

        [HttpGet]
        public async Task<IEnumerable<Domain.Models.Models.Group>> GetAllAsync(
           [FromQuery] int pageNumber,
           [FromQuery] int pageSize) =>
            await _mediator.Send(new GetAllRequest(pageNumber, pageSize));

        [HttpDelete("{groupId:int}")]
        public async Task DeleteAsync([FromRoute] int groupId) => 
            await _mediator.Send(new DeleteGroupRequest(groupId));
    }
}
