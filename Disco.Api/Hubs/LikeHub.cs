using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
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
        
        public async Task AddLike(int postId)
        {
            var likes = await serviceManager.LikeSevice.CreateLikeAsync(postId);

           await Clients.All.SendAsync("onLike", likes.Count);
        }

        public async Task RemoveLike(int postId)
        {
            var likes = await serviceManager.LikeSevice.RemoveLikeAsync(postId);

            await Clients.Caller.SendAsync("onRemoveLike", likes.Count);
        }
    }
}