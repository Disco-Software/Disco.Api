using Disco.BLL.Constants;
using Disco.BLL.Interfaces;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Hubs
{
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class LikeHub : Hub
    {
        private readonly IServiceManager serviceManager;
        public LikeHub(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;
        
        [HubMethodName("create")]
        public async Task AddLike(int postId)
        {
            var likes = await serviceManager.LikeSevice.CreateLikeAsync(postId);

           await Clients.All.SendAsync("create", likes.Count);
        }

        [HubMethodName("remove")]
        public async Task RemoveLike(int postId)
        {
            var likes = await serviceManager.LikeSevice.RemoveLikeAsync(postId);

            await Clients.All.SendAsync("remove", likes.Count);
        }
    }
}