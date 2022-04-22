using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Hubs
{
    public class PostHub : Hub
    {
        private readonly PostRepository postRepository;
        private readonly ApiDbContext ctx;
        public PostHub(
            PostRepository _postRepository,
            ApiDbContext _ctx)
        {
           postRepository = _postRepository;
            ctx = _ctx;
        }

        [Microsoft.AspNetCore.SignalR.HubMethodName("like")]
        public async Task AddLike(int postId)
        {
            var post = await postRepository.Get(postId);

            var postLikes = new Like { UserName = this.Context.User.Identity.Name, Post = post, PostId = postId };

            post.Likes.Add(postLikes);
            ctx.Like.Add(postLikes);

            ctx.SaveChanges();

            await Clients.All.SendAsync("sendAsync", post.Likes.Count);
        }
    }
}
