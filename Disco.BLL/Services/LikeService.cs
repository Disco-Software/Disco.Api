
using Disco.Business.Interfaces;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class LikeService : ILikeSevice
    {
        private readonly ApiDbContext ctx;
        private readonly PostRepository postRepository;
        private readonly LikeRepository likeRepository;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        public LikeService(
            ApiDbContext _ctx,
            PostRepository _postRepository,
            LikeRepository _likeRepository,
            UserManager<User> _userManager,
            IHttpContextAccessor _httpContextAccessor)
        {
            postRepository = _postRepository;
            likeRepository = _likeRepository;
            ctx = _ctx;
            userManager = _userManager;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<List<Like>> CreateLikeAsync(int postId)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var post = await postRepository.Get(postId);
           
            var like = new Like
            {
                Post = post,
                UserName = user.UserName,
                PostId = postId,
            };

            await likeRepository.AddAsync(like, postId);

            return post.Likes;
        }

        public async Task<List<Like>> RemoveLikeAsync(int postId)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var post = await postRepository.Get(postId);
            
            var like = post.Likes
                .Where(u => u.UserName == user.UserName)
                .FirstOrDefault();

           await likeRepository.Remove(like.Id);

            return post.Likes;
        }
    }
}
