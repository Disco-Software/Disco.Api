
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Disco.Domain.Models;
using Disco.ApiServices.Validators;
using Microsoft.AspNetCore.Cors;
using Disco.Business.Constants;
using AutoMapper;
using System;

namespace Disco.ApiServices.Controllers.Admin
{
    [Route("api/admin/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public AccountController(
            IAccountService accountService,
            IAccountPasswordService accountPasswordService,
            ITokenService tokenService,
            IEmailService emailService,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
            _tokenService = tokenService;
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn([FromForm] LoginDto model)
        {
            var validator = await LogInValidator
                .Create(_accountService)
                .ValidateAsync(model);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            var user = await _accountService.GetByEmailAsync(model.Email);

            var passwordValidator = await _accountPasswordService.VerifyPasswordAsync(user, model.Password);
            if (passwordValidator == PasswordVerificationResult.Failed)
            {
                return Unauthorized(passwordValidator);
            }

            var roleResult = await _accountService.IsInRoleAsync(user, UserRole.Admin);
            if(roleResult == false)
            {
                return Unauthorized();
            }
            
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, refreshToken);

            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            userResponseDto.AccessToken = accessToken;
            userResponseDto.RefreshToken = refreshToken;
            userResponseDto.User = user;

            return Ok(userResponseDto);
        }

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
        {
            var user = await _accountService.GetByRefreshTokenAsync(dto.RefreshToken);

            if (user == null)
                return BadRequest();

            if (user.RefreshTokenExpiress >= DateTime.UtcNow.AddDays(7))
            {
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var userRefreshedResponseDto = _mapper.Map<UserResponseDto>(user);
                userRefreshedResponseDto.AccessToken = accessToken;
                userRefreshedResponseDto.RefreshToken = refreshToken;
                userRefreshedResponseDto.User = user;

                return Ok(userRefreshedResponseDto);
            }

            var accessResponseToken = _tokenService.GenerateAccessToken(user);

            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            userResponseDto.AccessToken = accessResponseToken;
            userResponseDto.RefreshToken = user.RefreshToken;
            userResponseDto.User = user;

            return Ok(userResponseDto);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var user = await _accountService.GetByEmailAsync(dto.Email);

            if (user == null)
                return BadRequest("User is null");

            var passwordResetToken = await _accountPasswordService.GetPasswordConfirmationTokenAsync(user);

            _emailService.EmailConfirmation(new Business.Dtos.EmailNotifications.EmailConfirmationDto
            {
                ToEmail = user.Email,
                IsHtmlTemplate = true,
                MessageHeader = "Email confirmation"
            });

            return Ok(passwordResetToken);
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var user = await _accountService.GetByEmailAsync(dto.Email);

            if (user == null)
                return BadRequest();

            await _accountPasswordService.ChengePasswordAsync(user, dto.ConfirmationToken, dto.Password);

            return Ok("Password successfuly changed");
        }
    }
}