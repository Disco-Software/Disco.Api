using Disco.BLL.Constants;
using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.Friends;
using Disco.BLL.Services;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Controllers.Friend
{
    [Route("api/user/friends")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    [ApiController]
    public class UserFriendController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public UserFriendController(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;

        [HttpPost("create")]
        public async Task<FriendResponseModel> Create([FromBody] CreateFriendModel model) =>
            await serviceManager.FriendService.CreateFriendAsync(model);

        [HttpGet("get/{friendId:int}")]
        public async Task<FriendResponseModel> GetFriend([FromRoute] int friendId) =>
            await serviceManager.FriendService.GetFriendAsync(friendId);

        [HttpGet("{userId:int}")]
        public async Task<List<Disco.DAL.Entities.Friend>> GetAll([FromRoute] int userId) =>
            await serviceManager.FriendService.GetAllFriends(userId);

        [HttpDelete("{friendId:int}")]
        public async Task DeleteFriend([FromRoute] int friendId) =>
            await serviceManager.FriendService.DeleteFriend(friendId);

        [HttpPut("confirmation")]
        public async Task<FriendResponseModel> ConfirmFriend([FromBody] ConfirmationFriendModel model) =>
            await serviceManager.FriendService.IsConfirmFriendAsync(model);

    }
}
