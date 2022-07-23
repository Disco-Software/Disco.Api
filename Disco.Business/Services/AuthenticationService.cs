using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Configurations;
using Disco.Business.Constants;
using Disco.Business.Handlers;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Apple;
using Disco.Business.Dtos.Authentication;
using Disco.Business.Dtos.EmailNotifications;
using Disco.Business.Dtos.Facebook;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Google.Apis.Auth.AspNetCore3;
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
    public class AuthenticationService : ApiRequestHandlerBase, IAuthenticationService
    {
        private readonly ApiDbContext _ctx;
        private readonly UserManager<User> _userManager;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IGoogleAuthService _googleAuthService;
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly IEmailService _emailService;
        public AuthenticationService(
            ApiDbContext ctx,
            UserManager<User> userManager,
            BlobServiceClient blobServiceClient,
            IUserService userService,
            IUserRepository userRepository,
            ITokenService tokenService,
            IGoogleAuthService googleAuthService,
            IFacebookAuthService facebookAuthService,
            IEmailService emailService,
            IMapper mapper)
        {
            _userManager = userManager;
            _blobServiceClient = blobServiceClient;
            _userService = userService;
            _userRepository = userRepository;
            _facebookAuthService = facebookAuthService;
            _mapper = mapper;
            _tokenService = tokenService;
            _googleAuthService = googleAuthService;
            _emailService = emailService;
        }

        public async Task<UserResponseDto> LogIn(User user, string password)
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

        public async Task<UserResponseDto> Register(RegistrationDto dto)
        {
            var userResult = _mapper.Map<User>(dto);
            
            userResult.PasswordHash = _userManager.PasswordHasher.HashPassword(userResult, dto.Password);
            userResult.Profile = new Domain.Models.Profile { Status = StatusProvider.NewArtist };
            userResult.NormalizedEmail = _userManager.NormalizeEmail(userResult.Email);
            userResult.NormalizedUserName = _userManager.NormalizeName(userResult.UserName);
            userResult.RefreshToken = _tokenService.GenerateRefreshToken();
            userResult.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);
            
            var identityResult = await _userManager.CreateAsync(userResult);
            if (!identityResult.Succeeded)
                throw new Exception(identityResult.Errors.First().Description);

            var roleResult = await _userManager.AddToRoleAsync(userResult, "User");
            if (!roleResult.Succeeded)
                throw new Exception(roleResult.Errors.First().Description);

            userResult.RoleName = _userService.GetUserRole(userResult);

            var jwt = _tokenService.GenerateAccessToken(userResult);

            var userResponseModel = _mapper.Map<UserResponseDto>(userResult);
            userResponseModel.RefreshToken = userResult.RefreshToken;
            userResponseModel.AccessToken = jwt;
            userResponseModel.User = userResult;

            return userResponseModel;
        }

        public async Task<UserResponseDto> Facebook(FacebookDto dto)
        {
            var user = await _userManager.FindByLoginAsync(LogInProvider.Facebook, dto.Id);
            if(user != null)
            {
                await _userService.LoadUserInfoAsync(user);
                user.RoleName =  _userService.GetUserRole(user);

                user.Email = dto.Email;
                user.UserName = dto.FirstName;
                user.Profile.Photo = dto.Picture.Data.Url;

               await _userManager.UpdateAsync(user);

                var jwt = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var userResponseModel = _mapper.Map<UserResponseDto>(user);
                userResponseModel.AccessToken = jwt;
                userResponseModel.RefreshToken = refreshToken;
                userResponseModel.User = user;

                return userResponseModel;
            }

            user = await _userManager.FindByEmailAsync(dto.Email);
            if(user != null)
            {
                await _userService.LoadUserInfoAsync(user);
                user.RoleName = _userService.GetUserRole(user);

                await _userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Facebook, dto.Id, "FacebookId"));

                var jwt = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var userResponseModel = _mapper.Map<UserResponseDto>(user);
                userResponseModel.RefreshToken = refreshToken;
                userResponseModel.AccessToken = jwt;
                userResponseModel.User = user;

                return userResponseModel;
            }

            user = new User();
            user.UserName = dto.Name.Replace(" ", "_");
            user.Email = dto.Email;
            user.NormalizedEmail = _userManager.NormalizeEmail(dto.Email);
            user.NormalizedUserName = _userManager.NormalizeName(dto.Name);
            
            user.Profile = new Domain.Models.Profile();
            user.Profile.Status = StatusProvider.NewArtist;
            user.Profile.Photo = dto.Picture.Data.Url;

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);
            user.NormalizedEmail = _userManager.NormalizeEmail(user.Email);
            user.NormalizedUserName = _userManager.NormalizeName(user.UserName);

            var ideintityResult = await _userManager.CreateAsync(user);

            ideintityResult = await _userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Facebook, dto.Id, "FacebookId"));

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            user.RoleName = _userService.GetUserRole(user);

            var jwtToken = _tokenService.GenerateAccessToken(user);

            var userResponse = _mapper.Map<UserResponseDto>(user);
            userResponse.AccessToken = jwtToken;
            userResponse.RefreshToken = user.RefreshToken;
            userResponse.User = user;

            return userResponse;
        }

        public async Task<UserResponseDto> RefreshToken(User user, RefreshTokenDto model)
        {            
            if(user.RefreshTokenExpiress >= DateTime.UtcNow)
            {
                await _userService.SaveRefreshTokenAsync(user, model.RefreshToken);

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

        public async Task<UserResponseDto> Apple(AppleLogInDto model)
        {
            User user;
            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    user.UserName = model.Name;

                    await _userService.SaveRefreshTokenAsync(user, user.RefreshToken);

                    await _userManager.UpdateAsync(user);

                    var jwtToken = _tokenService.GenerateAccessToken(user);

                    var userResponseModel = _mapper.Map<UserResponseDto>(user);
                    userResponseModel.RefreshToken = user.RefreshToken;
                    userResponseModel.AccessToken = jwtToken;
                    userResponseModel.User = user;

                    return userResponseModel;
                }

                user = await _userManager.FindByLoginAsync(LogInProvider.Apple, model.Name);
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.Email = model.Email;

                    await _userService.SaveRefreshTokenAsync(user, user.RefreshToken);

                    await _userManager.UpdateAsync(user);

                    var jwtToken = _tokenService.GenerateAccessToken(user);

                    var userResponseResult = _mapper.Map<UserResponseDto>(user);
                    userResponseResult.RefreshToken = user.RefreshToken;
                    userResponseResult.AccessToken = jwtToken;
                    userResponseResult.User = user;

                    return userResponseResult;
                }

                user = new User
                {
                    UserName = model.Name,

                    Email = model.Email
                };
                user.NormalizedEmail = _userManager.NormalizeEmail(model.Email);
                user.NormalizedUserName = _userManager.NormalizeName(model.Name);

                var profile = new Domain.Models.Profile
                {
                    User = user,
                    UserId = user.Id,
                    Status = StatusProvider.NewArtist,
                };
                user.Profile = profile;

                await _userService.SaveRefreshTokenAsync(user, user.RefreshToken);

                var identity = await _userManager.CreateAsync(user);

                identity = await _userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Apple, model.AppleId, "AppleId"));

                var jwt = _tokenService.GenerateAccessToken(user);

                var userResponse = _mapper.Map<UserResponseDto>(user);
                userResponse.RefreshToken = user.RefreshToken;
                userResponse.AccessToken = jwt;
                userResponse.User = user;

                return userResponse;

            }
            return null;
        }

        public async Task<string> ForgotPassword(User user)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("templates");
            var blobClient = blobContainerClient.GetBlobClient("index.html");

            var uri = blobClient.Uri.AbsoluteUri;

            var html = (new WebClient()).DownloadString(uri);
            var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            string url = $"disco://disco.app/token/{passwordToken}";
            
            EmailConfirmationDto model = new EmailConfirmationDto();
            model.MessageHeader = "Email confirmation";
            model.MessageBody = html.Replace("[token]", passwordToken).Replace("[email]", user.Email);
            model.ToEmail = user.Email;
            model.IsHtmlTemplate = true;

            _emailService.EmailConfirmation(model);
            return passwordToken;
        }

        public async Task<UserResponseDto> ResetPassword(User user, ResetPasswordDto model)
        {            
            var identityResult = await _userManager.ResetPasswordAsync(user, model.ConfirmationToken, model.Password);
            if (!identityResult.Succeeded)
                throw new Exception($"You have sum errors {identityResult.Errors}");
            
            return new UserResponseDto { User = user, 
                RefreshToken = _tokenService.GenerateRefreshToken(), 
                AccessToken = _tokenService.GenerateAccessToken(user)};
        }

        public async Task<IActionResult> Google(IGoogleAuthProvider googleAuthProvider)
        {
            var googleResponse = await _googleAuthService.GetUserData(googleAuthProvider);

            var email = googleResponse.EmailAddresses.FirstOrDefault();
            var userName = googleResponse.Names.FirstOrDefault();
            var photo = googleResponse.Photos.FirstOrDefault();

            var user = new User
            {
                UserName = userName.DisplayName,
                Email = email.Value,
                Profile = new Domain.Models.Profile
                {
                    Photo = photo.Url,
                    Status = StatusProvider.NewArtist
                }
            };

            await _userManager.CreateAsync(user);

            var jwt = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var userResponse = _mapper.Map<UserResponseDto>(user);
            userResponse.RefreshToken = refreshToken;
            userResponse.AccessToken = jwt;
            userResponse.User = user;

            return Ok(userResponse);
        }
    }
}
