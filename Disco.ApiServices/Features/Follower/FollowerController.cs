using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Friends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Disco.Business.Interfaces.Validators;
using Disco.Business.Interfaces.Dtos.Friends;
using Disco.Business.Interfaces.Interfaces;
using System.Collections.Generic;
using Disco.Domain.Models.Models;
using System;
using Disco.ApiServices.Controllers;
using MediatR;
using Disco.Business.Interfaces.Dtos.Followers;
using Disco.ApiServices.Features.Follower.RequestHandlers.CreateFollower;
using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollower;
using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowers;
using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowing;
using Disco.ApiServices.Features.Follower.RequestHandlers.GetRecomended;
using Disco.ApiServices.Features.Follower.RequestHandlers.DeleteFollower;

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
        public async Task<ActionResult<FollowerResponseDto>> Create([FromBody] CreateFollowerDto dto) =>
            await _mediator.Send(new CreateFollowerRequest(dto));

        [HttpGet("{followerId:int}")]
        public async Task<ActionResult<FollowerResponseDto>> GetFollowerAsync([FromRoute] int followerId) =>
            await _mediator.Send(new GetFollowerRequest(followerId));

        [HttpGet("followers")]
        public async Task<ActionResult<List<UserFollower>>> GetFollowersAsync([FromQuery] GetFollowersDto dto) =>
            await _mediator.Send(new GetFollowersRequest(dto));

        [HttpGet("following")]
        public async Task<ActionResult<List<UserFollower>>> GetFollowingAsync([FromQuery] GetFollowersDto dto) =>
            await _mediator.Send(new GetFollowingRequest(dto));

        [HttpGet("recomend")]
        public async Task<ActionResult<List<Domain.Models.Models.Account>>> GetRecomendedAsync() =>
            await _mediator.Send(new GetRecomendedRequest());

        [HttpDelete("{followerId:int}")]
        public async Task DeleteFollowerAsync([FromRoute] int followerId) =>
            await _mediator.Send(new DeleteFollowerRequest(followerId));
    }
}
