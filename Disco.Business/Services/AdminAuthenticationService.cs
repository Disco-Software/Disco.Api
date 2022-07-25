using AutoMapper;
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
    public class AdminAuthenticationService : IAdminAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;

        public AdminAuthenticationService(
            UserManager<User> userManager,
            BlobServiceClient blobServiceClient,
            IMapper mapper,
            IUserService userService,
            ITokenService tokenService, 
            IEmailService emailService)
        {
            this._userManager = userManager;
            this._blobServiceClient = blobServiceClient;
            this._mapper = mapper;
            this._userService = userService;
            this._tokenService = tokenService;
            this._emailService = emailService;
        }

        public async Task<string> ForgotPassword(User user, ForgotPasswordDto model)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("templates");
            var blobClient = blobContainerClient.GetBlobClient("index.html");

            var uri = blobClient.Uri.AbsoluteUri;

            var html = (new WebClient()).DownloadString(uri);
            var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            string url = $"disco://disco.app/token/{passwordToken}";
            
            EmailConfirmationDto emailModel = new EmailConfirmationDto();
            emailModel.MessageHeader = "Email confirmation";
            emailModel.MessageBody = html.Replace("[token]", passwordToken).Replace("[email]", user.Email);
            emailModel.ToEmail = model.Email;
            emailModel.IsHtmlTemplate = true;

            _emailService.EmailConfirmation(emailModel);
            
            return passwordToken;
        }

        public async Task<UserResponseDto> LogIn(User user, LoginDto dto)
        {
            var jwt = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _userService.SaveRefreshTokenAsync(user, refreshToken);

            var userResponseModel = _mapper.Map<UserResponseDto>(user);
            userResponseModel.RefreshToken = refreshToken;
            userResponseModel.AccessToken = jwt;
            userResponseModel.User = user;

            return userResponseModel;
        }

        public async Task<UserResponseDto> RefreshToken(User user, RefreshTokenDto dto)
        {
            if (user.RefreshTokenExpiress >= DateTime.UtcNow)
            {
                await _userService.SaveRefreshTokenAsync(user, dto.RefreshToken);

                var jwtToken = _tokenService.GenerateAccessToken(user);

                var userResponseModel = _mapper.Map<UserResponseDto>(user);
                userResponseModel.RefreshToken = user.RefreshToken;
                userResponseModel.AccessToken = jwtToken;
                userResponseModel.User = user;

                return userResponseModel;
            }

            var jwt = _tokenService.GenerateAccessToken(user);

            var userResponse = _mapper.Map<UserResponseDto>(user);
            userResponse.RefreshToken = user.RefreshToken;
            userResponse.AccessToken = jwt;
            userResponse.User = user;

            return userResponse;
        }

        public async Task<UserResponseDto> ResetPassword(User user, ResetPasswordDto model)
        {
            var identityResult = await _userManager.ResetPasswordAsync(user, model.ConfirmationToken, model.Password);
            if (!identityResult.Succeeded)
                throw new Exception($"You have sum errors {identityResult.Errors}");

            return new UserResponseDto
            {
                User = user,
                RefreshToken = _tokenService.GenerateRefreshToken(),
                AccessToken = _tokenService.GenerateAccessToken(user)
            };
        }

        Task<UserResponseDto> IAdminAuthenticationService.RefreshToken(RefreshTokenDto model)
        {
            throw new NotImplementedException();
        }
    }
}
