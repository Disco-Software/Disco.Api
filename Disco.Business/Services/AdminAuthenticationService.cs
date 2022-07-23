﻿using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Configurations;
using Disco.Business.Handlers;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Authentication;
using Disco.Business.Dtos.EmailNotifications;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Disco.Business.Validators;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class AdminAuthenticationService : ApiRequestHandlerBase, IAdminAuthenticationService
    {
        private readonly ApiDbContext ctx;
        private readonly UserManager<User> userManager;
        private readonly BlobServiceClient blobServiceClient;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;
        private readonly IEmailService emailService;

        public AdminAuthenticationService(
            ApiDbContext ctx, 
            UserManager<User> userManager, 
            BlobServiceClient blobServiceClient,
            IMapper mapper,
            IUserRepository userRepository,
            ITokenService tokenService, 
            IEmailService emailService)
        {
            this.ctx = ctx;
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.blobServiceClient = blobServiceClient;
            this.mapper = mapper;
            this.tokenService = tokenService;
            this.emailService = emailService;
        }

        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            var blobContainerClient = blobServiceClient.GetBlobContainerClient("templates");
            var blobClient = blobContainerClient.GetBlobClient("index.html");

            var uri = blobClient.Uri.AbsoluteUri;

            var html = (new WebClient()).DownloadString(uri);
            var passwordToken = await userManager.GeneratePasswordResetTokenAsync(user);
            string url = $"disco://disco.app/token/{passwordToken}";
            EmailConfirmationDto emailModel = new EmailConfirmationDto();
            emailModel.MessageHeader = "Email confirmation";
            emailModel.MessageBody = html.Replace("[token]", passwordToken).Replace("[email]", user.Email);
            emailModel.ToEmail = model.Email;
            emailModel.IsHtmlTemplate = true;

            emailService.EmailConfirmation(emailModel);
            return Ok(passwordToken);
        }

        public async Task<IActionResult> LogIn(LoginDto model)
        {
            var validator = await LogInValidator
                .Create()
                .ValidateAsync(model);

            if (validator.Errors.Count > 0)
                return BadRequest(validator);

            var user = await userManager.FindByEmailAsync(model.Email);

            await ctx.Entry(user)
                .Reference(p => p.Profile)
                .LoadAsync();

            await ctx.Entry(user.Profile)
                .Collection(p => p.Posts)
                .LoadAsync();

            await ctx.Entry(user.Profile)
                .Collection(f => f.Followers)
                .LoadAsync();

            var passwordVarification = userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (passwordVarification == PasswordVerificationResult.Failed)
                return BadRequest("Password is not valid");

            user.RoleName = ctx.UserRoles
                .Join(ctx.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                .Where(r => r.UserRole.UserId == user.Id)
                .FirstOrDefaultAsync().Result.Role.Name;

            var roleResult = await userManager.IsInRoleAsync(user, "Admin");
            if (!roleResult == true)
                return BadRequest("You need to have role Admin to login");

            var jwt = tokenService.GenerateAccessToken(user);
            var refreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

            await ctx.SaveChangesAsync();

            var userResponseModel = mapper.Map<UserResponseDto>(user);
            userResponseModel.RefreshToken = refreshToken;
            userResponseModel.AccessToken = jwt;
            userResponseModel.User = user;

            return Ok(userResponseModel);
        }

        public async Task<IActionResult> RefreshToken(RefreshTokenDto model)
        {
            var user = await userRepository.GetUserByRefreshTokenAsync(model.RefreshToken);

            if (user == null)
                return BadRequest("User not found");

            var roleResult = await userManager.IsInRoleAsync(user, "Admin");
            if (!roleResult == true)
                return BadRequest("You can not use this functionality, becose you are not administrator");

            if (user.RefreshTokenExpiress >= DateTime.UtcNow)
            {
                user.RefreshToken = tokenService.GenerateRefreshToken();
                user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

                await ctx.SaveChangesAsync();

                var jwtToken = tokenService.GenerateAccessToken(user);

                var userResponseModel = mapper.Map<UserResponseDto>(user);
                userResponseModel.RefreshToken = user.RefreshToken;
                userResponseModel.AccessToken = jwtToken;
                userResponseModel.User = user;

                return Ok(userResponseModel);
            }

            var jwt = tokenService.GenerateAccessToken(user);

            var userResponse = mapper.Map<UserResponseDto>(user);
            userResponse.RefreshToken = user.RefreshToken;
            userResponse.AccessToken = jwt;
            userResponse.User = user;

            return Ok(userResponse);
        }

        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            var roleResult = await userManager.IsInRoleAsync(user, "Admin");
            if (!roleResult == true)
                return BadRequest("You can not use this functionality, becose you are not administrator");

            var identityResult = await userManager.ResetPasswordAsync(user, model.ConfirmationToken, model.Password);
            if (!identityResult.Succeeded)
                return BadRequest(identityResult.Errors);
           
            return Ok(user);
        }
    }
}
