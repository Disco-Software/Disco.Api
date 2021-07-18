using Disco.BLL.Models.DTO;
using Disco.BLL.Services;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Disco.BLL.Interfaces;

namespace Disco.Server.Controllers.Authorization
{
    [Route("api/user/auth")]
    public class UserAuthenticationController : Controller
    {
        private readonly IAccountService accountService;
        public UserAuthenticationController(IAccountService _accountService) =>
            this.accountService = _accountService;
       
        /// <summary>
        /// Вход в систему, под существующем аккаунтом
        /// </summary>
        /// <param name="dto">Информация об аккаунте</param>
        /// <returns>
        /// Пользоваетля, есле он существует, если же нет, то возвращет ответ, почему Вы не можете войти в систему
        /// </returns>
        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var user = await accountService.Login(dto);
            return Ok(user);
        }

        /// <summary>
        /// Регестрирует нового пользоваетля
        /// </summary>
        /// <param name="dto">Базовая информация о пользователе</param>
        /// <returns>
        /// Нового пользователя
        /// </returns>
        [HttpPost("register"), AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterDTO dto)
        {
            var user = await accountService.Register(dto);
            return Ok(user);
        }

        [HttpPut("reset-password"), AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromQuery] ForgotPasswordDTO forgotPassword)
        {
            var password = await accountService.ForgotPassword(forgotPassword);
            return Ok(password);
        }
    }
}
