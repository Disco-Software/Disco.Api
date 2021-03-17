using Disco.DAL.EF;
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

namespace Disco.Server.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext ctx;
        private ApplicationUserManager userManager;
        private string userId;
        public UserController(ApplicationUserManager manager, ApplicationDbContext ctx)
        {
            this.ctx = ctx;
            this.userManager = manager;
        }
        [Authorize]
        [HttpGet]
        [Route("userSongs")]
        public async Task<IActionResult> GetUserSongs()
        {
            var userId = userManager.GetUserId(User);
            var user = ctx.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            var postRepo = new PostRepository(ctx);
            var posts = postRepo.GetAll(p => p.UserId == userId);
            return new JsonResult(new {posts = posts, user=user });
        }
    }
}