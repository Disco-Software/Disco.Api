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
            _ctx = ctx;
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

        public async Task<IActionResult> Facebook(FacebookRequestDto facebookRequestModel)
        {
            var validator = await FacebookAccessTokenValidator
                .Create()
                .ValidateAsync(facebookRequestModel);

            if (validator.Errors.Count > 0)
                return BadRequest(validator);

            var userInfo = await _facebookAuthService.GetUserInfo(facebookRequestModel.AccessToken);

            if (userInfo == null)
                return BadRequest("info can't be null");

            var user = await _userManager.FindByLoginAsync(LogInProvider.Facebook, userInfo.Id);

            if(user != null)
            {
                await _ctx.Entry(user)
                        .Reference(p => p.Profile)
                        .LoadAsync();
                
                user.RoleName = _ctx.UserRoles
                     .Join(_ctx.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                     .Where(r => r.UserRole.UserId == user.Id)
                     .FirstOrDefaultAsync().Result.Role.Name;

                user.Email = userInfo.Email;
                user.UserName = userInfo.FirstName;
                user.Profile.Photo = userInfo.Picture.Data.Url;

               await _userManager.UpdateAsync(user);

                var jwt = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var userResponseModel = _mapper.Map<UserResponseDto>(user);
                userResponseModel.AccessToken = jwt;
                userResponseModel.RefreshToken = refreshToken;
                userResponseModel.User = user;

                return Ok(userResponseModel);
            }

            user = await _userManager.FindByEmailAsync(userInfo.Email);
            if(user != null)
            {
               await _ctx.Entry(user)
                    .Reference(p => p.Profile)
                    .LoadAsync();

                user.RoleName = _ctx.UserRoles
                        .Join(_ctx.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                        .Where(r => r.UserRole.UserId == user.Id)
                        .FirstOrDefaultAsync().Result.Role.Name;


                await _userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Facebook, userInfo.Id, "FacebookId"));

                var jwt = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var userResponseModel = _mapper.Map<UserResponseDto>(user);
                userResponseModel.RefreshToken = refreshToken;
                userResponseModel.AccessToken = jwt;
                userResponseModel.User = user;

                return Ok(userResponseModel);
            }

            user = new User();
            user.UserName = userInfo.Name.Replace(" ", "_");
            user.Email = userInfo.Email;
            user.NormalizedEmail = _userManager.NormalizeEmail(userInfo.Email);
            user.NormalizedUserName = _userManager.NormalizeName(userInfo.Name);
            
            user.Profile = new Domain.Models.Profile();
            user.Profile.Status = StatusProvider.NewArtist;
            user.Profile.Photo = userInfo.Picture.Data.Url;

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);
            user.NormalizedEmail = _userManager.NormalizeEmail(user.Email);
            user.NormalizedUserName = _userManager.NormalizeName(user.UserName);

            var ideintityResult = await _userManager.CreateAsync(user);

            ideintityResult = await _userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Facebook, userInfo.Id, "FacebookId"));

            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (!roleResult.Succeeded)
                return BadRequest(roleResult.Errors);
            
            user.RoleName = _ctx.UserRoles
                  .Join(_ctx.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                  .Where(r => r.UserRole.UserId == user.Id)
                  .FirstOrDefaultAsync().Result.Role.Name;

            var jwtToken = _tokenService.GenerateAccessToken(user);

            var userResponse = _mapper.Map<UserResponseDto>(user);
            userResponse.AccessToken = jwtToken;
            userResponse.RefreshToken = user.RefreshToken;
            userResponse.User = user;

            return Ok(userResponse);
        }

        public async Task<IActionResult> RefreshToken(RefreshTokenDto model)
        {
            var user = await _userRepository.GetUserByRefreshTokenAsync(model.RefreshToken);
                           
            if (user == null)
                return BadRequest("User not found");
            
            if(user.RefreshTokenExpiress >= DateTime.UtcNow)
            {                
                user.RefreshToken = _tokenService.GenerateRefreshToken();
                user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);
                
                await _ctx.SaveChangesAsync();

                var jwtToken = _tokenService.GenerateAccessToken(user);

                var userResponseModel = _mapper.Map<UserResponseDto>(user);
                userResponseModel.RefreshToken = user.RefreshToken;
                userResponseModel.AccessToken = jwtToken;
                userResponseModel.User = user;

                return Ok(userResponseModel);
            }

            var jwt = _tokenService.GenerateAccessToken(user);

            var userResponse = _mapper.Map<UserResponseDto>(user);
            userResponse.RefreshToken = user.RefreshToken;
            userResponse.AccessToken = jwt;
            userResponse.User = user;

            return Ok(userResponse);
        }

        public async Task<IActionResult> Apple(AppleLogInDto model)
        {
            User user;
            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.RefreshToken = _tokenService.GenerateRefreshToken();
                    user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

                    await _userManager.UpdateAsync(user);

                    var jwtToken = _tokenService.GenerateAccessToken(user);

                    var userResponseModel = _mapper.Map<UserResponseDto>(user);
                    userResponseModel.RefreshToken = user.RefreshToken;
                    userResponseModel.AccessToken = jwtToken;
                    userResponseModel.User = user;

                    return Ok(userResponseModel);
                }

                user = await _userManager.FindByLoginAsync(LogInProvider.Apple, model.Name);
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.Email = model.Email;
                    user.RefreshToken = _tokenService.GenerateRefreshToken();
                    user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

                    await _userManager.UpdateAsync(user);

                    var jwtToken = _tokenService.GenerateAccessToken(user);

                    var userResponseResult = _mapper.Map<UserResponseDto>(user);
                    userResponseResult.RefreshToken = user.RefreshToken;
                    userResponseResult.AccessToken = jwtToken;
                    userResponseResult.User = user;

                    return Ok(userResponseResult);
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
                user.RefreshToken = _tokenService.GenerateRefreshToken();
                user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

                var identity = await _userManager.CreateAsync(user);
                if (!identity.Succeeded)
                    return BadRequest(identity.Errors.FirstOrDefault().Description);

                identity = await _userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Apple, model.AppleId, "AppleId"));
                if (!identity.Succeeded)
                    return BadRequest(identity.Errors.FirstOrDefault().Description);

                var jwt = _tokenService.GenerateAccessToken(user);

                var userResponse = _mapper.Map<UserResponseDto>(user);
                userResponse.RefreshToken = user.RefreshToken;
                userResponse.AccessToken = jwt;
                userResponse.User = user;

                return Ok(userResponse);

            }
            return null;
        }

        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("templates");
            var blobClient = blobContainerClient.GetBlobClient("index.html");

            var uri = blobClient.Uri.AbsoluteUri;

            var html = (new WebClient()).DownloadString(uri);
            var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            string url = $"disco://disco.app/token/{passwordToken}";
            EmailConfirmationDto model = new EmailConfirmationDto();
            model.MessageHeader = "Email confirmation";
            model.MessageBody = html.Replace("[token]", passwordToken).Replace("[email]", user.Email);
            model.ToEmail = email;
            model.IsHtmlTemplate = true;

            _emailService.EmailConfirmation(model);
            return Ok(passwordToken);
        }

        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            
            var identityResult = await _userManager.ResetPasswordAsync(user, model.ConfirmationToken, model.Password);
            if (!identityResult.Succeeded)
                throw new Exception($"You have sum errors {identityResult.Errors}");
            return Ok(user);
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
