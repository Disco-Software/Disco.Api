using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Disco.ApiServices.Hubs
{
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class LikeHub : Hub
    {
        private readonly ILikeSevice likeSevice;
        public LikeHub(ILikeSevice _likeSevice)
        {
            likeSevice = _likeSevice;
        }
        
        public async Task AddLike(int postId)
        {
            var likes = await likeSevice.CreateLikeAsync(postId);

           await Clients.All.SendAsync("onLike", likes.Count);
        }

        public async Task RemoveLike(int postId)
        {
            var likes = await likeSevice.RemoveLikeAsync(postId);

            await Clients.Caller.SendAsync("onRemoveLike", likes.Count);
        }
    }
}