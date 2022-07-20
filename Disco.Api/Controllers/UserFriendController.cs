using Disco.BLL.Constants;
using Disco.BLL.Dto;
using Disco.BLL.Interfaces;
using Disco.BLL.Dto;
using Disco.BLL.Dto.Friends;
using Disco.BLL.Services;
using Disco.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [Route("api/user/friends")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    [ApiController]
    public class UserFriendController : ControllerBase
    {
        private readonly IFriendService friendService;

        public UserFriendController(IFriendService _friendService)
        {
            friendService = _friendService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateFriendDto model)
        {
            return await friendService.CreateFriendAsync(model);
        }

        [HttpGet("get/{friendId:int}")]
        public async Task<IActionResult> GetFriend([FromRoute] int friendId)
        {
            return await friendService.GetFriendAsync(friendId);
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetAll([FromRoute] int userId)
        {
            return await friendService.GetAllFriends(userId);
        }

        [HttpDelete("{friendId:int}")]
        public async Task DeleteFriend([FromRoute] int friendId)
        {
            await friendService.DeleteFriend(friendId);
        }
    }
}
