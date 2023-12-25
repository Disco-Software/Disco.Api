using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Follower.RequestHandlers.CreateFollower;
using Disco.ApiServices.Features.Follower.RequestHandlers.DeleteFollower;
using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollower;
using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowers;
using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowing;
using Disco.ApiServices.Features.Follower.RequestHandlers.GetRecomended;
using Disco.Business.Interfaces.Dtos.Followers.User.CreateFollower;
using Disco.Business.Interfaces.Dtos.Followers.User.GetFollower;
using Disco.Business.Interfaces.Dtos.Followers.User.GetFollowers;
using Disco.Business.Interfaces.Dtos.Followers.User.GetFollowing;
using Disco.Business.Interfaces.Dtos.Followers.User.GetRecomended;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower
{
    [Route("api/user/followers")]
    public class FollowerController : UserController
    {
        private readonly IMediator _mediator;
        
        public FollowerController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<CreateFollowerResponseDto>> Create([FromBody] CreateFollowerRequestDto dto) =>
            await _mediator.Send(new CreateFollowerRequest(dto));

        [HttpGet("{followerId:int}")]
        public async Task<ActionResult<GetFollowerResponseDto>> GetFollowerAsync([FromRoute] int followerId) =>
            await _mediator.Send(new GetFollowerRequest(followerId));

        [HttpGet("followers")]
        public async Task<IEnumerable<GetFollowersResponseDto>> GetFollowersAsync([FromQuery] GetFollowersRequestDto dto) =>
            await _mediator.Send(new GetFollowersRequest(dto));

        [HttpGet("following")]
        public async Task<IEnumerable<GetFollowingResponseDto>> GetFollowingAsync([FromQuery] Business.Interfaces.Dtos.Followers.User.GetFollowing.GetFollowingRequestDto dto) =>
            await _mediator.Send(new GetFollowingRequest(dto));

        [HttpGet("recomend")]
        public async Task<IEnumerable<GetRecomendedResponseDto>> GetRecomendedAsync(
            [FromQuery] int userId,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize) =>
            await _mediator.Send(new GetRecomendedRequest(userId, pageNumber, pageSize));

        [HttpDelete("{followerId:int}")]
        public async Task DeleteFollowerAsync([FromRoute] int followerId) =>
            await _mediator.Send(new DeleteFollowerRequest(followerId));
    }
}
