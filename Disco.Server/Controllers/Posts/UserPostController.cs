using Disco.BLL.Services;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Identity;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Disco.Server.Controllers.Post
{
    [Route("api/user/posts"), Authorize]
    public class UserPostController : Controller
    {
        private readonly ApplicationDbContext ctx;
        private readonly ApplicationUserManager userManager;
        private readonly NotificationService service;
        public UserPostController(ApplicationUserManager manager, ApplicationDbContext ctx, NotificationService service)
        {
            this.ctx = ctx;
            this.userManager = manager;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetUserPosts()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            //var user = ctx.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            var postRepo = new PostRepository(ctx);
            var posts = await postRepo.GetAll(p => p.UserId.Equals(user.Id));
             return new JsonResult(new {posts = posts, user=user });
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserPost(DAL.Entities.Post post)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            DAL.Entities.Post userPost = new DAL.Entities.Post
            {
                UserId = userId,
                Id = post.Id,
                //Photos = post.Photo,
                //Songs = post.Sound,
                //Video = post.Video,
                Description = post.Description
            };
            PostRepository repo = new PostRepository(ctx);
            await repo.Create(userPost);
            await ctx.SaveChangesAsync();
            return new JsonResult(userPost);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUserPost(int postId)
        {
            PostRepository repo = new PostRepository(ctx);
            await repo.Delete(postId);
            await ctx.SaveChangesAsync();
            return new JsonResult(new { result = "Post is removed" });
        }
    }
}