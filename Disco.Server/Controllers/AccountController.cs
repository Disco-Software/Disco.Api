using Disco.BLL.DTO;
using Disco.BLL.Services;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Server.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager manager;
        private ApplicationDbContext ctx;
        public AccountController(ApplicationUserManager manager, ApplicationDbContext ctx)
        {
            this.ctx = ctx;
            this.manager = manager;
        }
        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            UserService service = new UserService(manager, ctx);
            var user = await service.Login(dto);
            return new JsonResult(user);
        }

        [HttpGet]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            UserService service = new UserService(manager, ctx);
            var user = await service.Register(dto);
            return new JsonResult(user);
        }
    }
}
