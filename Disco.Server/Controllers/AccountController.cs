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
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            UserService service = new UserService(manager, ctx);
            var user = await service.Login(dto);
            return new JsonResult(user);
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            User user = await manager.FindByEmailAsync(dto.Email);
            UserService service = new UserService(manager,ctx);
            if(user is null)
            {
               var userResult = await service.Register(dto);
                return new JsonResult(userResult);
            }
            else
            {
                return new JsonResult(new { Message = "This user allready created" });
            }
        }
    }
}
