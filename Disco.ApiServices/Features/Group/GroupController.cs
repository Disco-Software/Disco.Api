using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Group.RequestHandlers.CreateGroup;
using Disco.ApiServices.Features.Group.RequestHandlers.DeleteGroup;
using Disco.ApiServices.Features.Group.RequestHandlers.GetAll;
using Disco.ApiServices.Features.Group.RequestHandlers.GetGroupMessages;
using Disco.Business.Interfaces.Dtos.Group.User.CreateGroup;
using Disco.Business.Interfaces.Dtos.Group.User.GetAllGroupMessages;
using Disco.Business.Interfaces.Dtos.Group.User.GetAllGroups;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Group
{
    [Route("api/user/groups")]
    public class GroupController : UserController
    {
        private readonly IMediator _mediator;

        public GroupController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<CreateGroupResponseDto>> CreateAsync([FromBody] Business.Interfaces.Dtos.Group.User.CreateGroup.CreateGroupRequestDto dto) =>
            await _mediator.Send(new CreateGroupRequest(dto));

        [HttpGet]
        public async Task<IEnumerable<GetAllGroupsResponseDto>> GetAllAsync(
           [FromQuery] int pageNumber,
           [FromQuery] int pageSize) =>
            await _mediator.Send(new GetAllGroupsRequest(pageNumber, pageSize));

        [HttpGet("messages")]
        public async Task<IEnumerable<GetAllGroupMessagesResponseDto>> GetGroupMessagesAsync(
            [FromQuery] int groupId,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize) =>
            await _mediator.Send(new GetGroupMessagesRequest(groupId, pageNumber, pageSize));

        [HttpDelete("{groupId:int}")]
        public async Task DeleteAsync([FromRoute] int groupId) => 
            await _mediator.Send(new DeleteGroupRequest(groupId));
    }
}
