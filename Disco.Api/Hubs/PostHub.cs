using Disco.BLL.Interfaces;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
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
    public class PostHub : Hub
    {
        private readonly IServiceManager serviceManager;
        public PostHub(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;
        
        [HubMethodName("add")]
        public async Task AddLike(int postId)
        {
            var likes = await serviceManager.LikeSevice.CreateLikeAsync(postId);

           await Clients.All.SendAsync("add", likes.Count);
        }
    }
}
