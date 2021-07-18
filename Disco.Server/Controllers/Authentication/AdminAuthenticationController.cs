using Disco.BLL.Models.DTO;
using Disco.BLL.Services;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Server.Controllers.Authentication
{
    public class AdminAuthenticationController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly SignInManager<DAL.Entities.User> signInManager;
        private readonly ApplicationUserManager _manager;
        public AdminAuthenticationController(ApplicationDbContext ctx, ApplicationUserManager manager)
        {
            context = ctx;
            _manager = manager;
        }

        public async Task<IActionResult> Login(LoginDTO dto)
        {
            AccountService service = new BLL.Services.AccountService(_manager,signInManager ,context);
            var userDTO = await service.Login(dto);
            return new JsonResult(new { user = userDTO });
        }
    }
}
