using Disco.BLL.Interfaces;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class LikeService : ILikeSevice
    {
        private readonly ApiDbContext ctx;
        private readonly PostRepository postRepository;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        public LikeService(
            ApiDbContext _ctx,
            PostRepository _postRepository,
            UserManager<User> _userManager,
            IHttpContextAccessor _httpContextAccessor)
        {
            postRepository = _postRepository;
            ctx = _ctx;
            userManager = _userManager;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<List<Like>> CreateLikeAsync(int postId)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var post = await postRepository.Get(postId);

            var like = post.Likes.Where(l => l.UserName == user.UserName).FirstOrDefault();
           
            if(like != null)
            {
                post.Likes.Remove(like);
                ctx.Like.Remove(like);
                
                await ctx.SaveChangesAsync();
             
                return post.Likes;
            }

            like = new Like
            {
                Post = post,
                UserName = user.UserName,
                PostId = postId,
            };

            post.Likes.Add(like);
            ctx.Like.Add(like);

            await ctx.SaveChangesAsync();

            return post.Likes;
        }

        public async Task RemoveLikeAsync(int likeId)
        {
            var like = await ctx.Like
                .Where(l => l.Id == likeId)
                .FirstOrDefaultAsync();

            ctx.Remove(like);
        }
    }
}
