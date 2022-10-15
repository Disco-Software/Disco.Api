using Disco.Business.Dtos.Authentication;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Route("api/user/account/password")]
    public class AccountPasswordController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly IEmailService _emailService;

        public AccountPasswordController(
            IAccountService accountService,
            IAccountPasswordService accountPasswordService,
            IEmailService emailService)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
            _emailService = emailService;
        }

        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            var user = await _accountService.GetByEmailAsync(model.Email);

            if (user == null)
                BadRequest("User is null");

            var passwordResetToken = await _accountPasswordService.GetPasswordConfirmationTokenAsync(user);

            _emailService.EmailConfirmation(new Business.Dtos.EmailNotifications.EmailConfirmationDto
            {
                ToEmail = user.Email,
                IsHtmlTemplate = true,
                MessageHeader = "Email confirmation"
            });

            return Ok(passwordResetToken);
        }

        [HttpPut("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var user = await _accountService.GetByEmailAsync(dto.Email);

            if (user == null)
                return BadRequest();

            await _accountPasswordService.ChengePasswordAsync(user, dto.ConfirmationToken, dto.Password);

            return Ok("Password successfuly reset");
        }
    }
}
