using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Disco.ApiServices.Hubs
{
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class LikeHub : Hub
    {
        private readonly ILikeService _likeSevice;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LikeHub(
            ILikeService likeSevice,
            IUserService userService,
            IHttpContextAccessor httpContextAccessor)
        {
            _likeSevice = likeSevice;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddLike(int postId)
        {
            var user = await _userService.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var likes = await _likeSevice.CreateLikeAsync(user, postId);

           await Clients.All.SendAsync("onLike", likes.Count);
        }

        public async Task RemoveLike(int postId)
        {
            var user = await _userService.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var likes = await _likeSevice.RemoveLikeAsync(user, postId);

            await Clients.Caller.SendAsync("onRemoveLike", likes.Count);
        }
    }
}