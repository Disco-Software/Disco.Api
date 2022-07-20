using AutoMapper;
using Azure.Storage.Blobs;
using Disco.BLL.Configurations;
using Disco.BLL.Constants;
using Disco.BLL.Dto;
using Disco.BLL.Handlers;
using Disco.BLL.Interfaces;
using Disco.BLL.Dto;
using Disco.BLL.Dto.Apple;
using Disco.BLL.Dto.Authentication;
using Disco.BLL.Dto.EmailNotifications;
using Disco.BLL.Dto.Facebook;
using Disco.BLL.Dto.Google;
using Disco.BLL.Validatars;
using Disco.DAL.EF;
using Disco.DAL.Models;
using Disco.DAL.Repositories;
using FluentValidation.Results;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class AuthenticationService : ApiRequestHandlerBase, IAuthenticationService
    {
        private readonly ApiDbContext ctx;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly BlobServiceClient blobServiceClient;
        private readonly UserRepository userRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;
        private readonly IGoogleAuthService googleAuthService;
        private readonly IFacebookAuthService facebookAuthService;
        private readonly IOptions<AuthenticationOptions> authenticationOptions;
        private readonly IEmailService emailService;
        private readonly IOptions<GoogleOptions> googleOptions;
        public AuthenticationService(ApiDbContext _ctx,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            BlobServiceClient _blobServiceClient,
            UserRepository _userRepository,
            IHttpContextAccessor _httpContextAccessor,
            ITokenService _tokenService,
            IGoogleAuthService _googleAuthService,
            IFacebookAuthService _facebookAuthService,
            IEmailService _emailService,
            IOptions<AuthenticationOptions> _authenticationOptions,
            IOptions<GoogleOptions> _googleOptions,
            IMapper _mapper)
        {
            ctx = _ctx;
            userManager = _userManager;
            signInManager = _signInManager;
            blobServiceClient = _blobServiceClient;
            userRepository = _userRepository;
            facebookAuthService = _facebookAuthService;
            mapper = _mapper;
            authenticationOptions = _authenticationOptions;
            tokenService = _tokenService;
            googleAuthService = _googleAuthService;
            emailService = _emailService;
            httpContextAccessor = _httpContextAccessor;
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
                .Join(ctx.Roles, r => r.RoleId,u => u.Id, (u,r) => new {Role = r, UserRole = u})
                .Where(r => r.UserRole.UserId == user.Id)
                .FirstOrDefaultAsync().Result.Role.Name;

            await signInManager.SignInAsync(user, true);
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

        public async Task<IActionResult> Register(RegistrationDto userInfo)
        {
            var validator = await RegistrationValidator
                .Create(userManager)
                .ValidateAsync(userInfo);

            if(validator.Errors.Count > 0)
                return BadRequest(validator);

            var userResult = mapper.Map<User>(userInfo);
            
            userResult.PasswordHash = userManager.PasswordHasher.HashPassword(userResult, userInfo.Password);
            userResult.Profile = new DAL.Models.Profile { Status = StatusProvider.NewArtist };
            userResult.NormalizedEmail = userManager.NormalizeEmail(userResult.Email);
            userResult.NormalizedUserName = userManager.NormalizeName(userResult.UserName);
            userResult.RefreshToken = tokenService.GenerateRefreshToken();
            userResult.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);
            
            var roleResult = await userManager.AddToRoleAsync(userResult, "User");
            if (!roleResult.Succeeded)
                return BadRequest(roleResult.Errors);

            userResult.RoleName = ctx.UserRoles
                    .Join(ctx.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                    .Where(r => r.UserRole.UserId == userResult.Id)
                    .FirstOrDefaultAsync().Result.Role.Name;

            var identityResult = await userManager.CreateAsync(userResult);
            if (!identityResult.Succeeded)
                return BadRequest(identityResult.Errors);
            
            await ctx.SaveChangesAsync();

            await signInManager.SignInAsync(userResult, true);
            var jwt = tokenService.GenerateAccessToken(userResult);

            var userResponseModel = mapper.Map<UserResponseDto>(userResult);
            userResponseModel.RefreshToken = userResult.RefreshToken;
            userResponseModel.AccessToken = jwt;
            userResponseModel.User = userResult;

            return Ok(userResponseModel);
        }

        public async Task<IActionResult> Facebook(FacebookRequestDto facebookRequestModel)
        {
            var validator = await FacebookAccessTokenValidator
                .Create()
                .ValidateAsync(facebookRequestModel);

            if (validator.Errors.Count > 0)
                return BadRequest(validator);

            var userInfo = await facebookAuthService.GetUserInfo(facebookRequestModel.AccessToken);

            if (userInfo == null)
                return BadRequest("info can't be null");

            var user = await userManager.FindByLoginAsync(LogInProvider.Facebook, userInfo.Id);

            if(user != null)
            {
                await ctx.Entry(user)
                        .Reference(p => p.Profile)
                        .LoadAsync();
                
                user.RoleName = ctx.UserRoles
                     .Join(ctx.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                     .Where(r => r.UserRole.UserId == user.Id)
                     .FirstOrDefaultAsync().Result.Role.Name;

                user.Email = userInfo.Email;
                user.UserName = userInfo.FirstName;
                user.Profile.Photo = userInfo.Picture.Data.Url;

               await userManager.UpdateAsync(user);

                var jwt = tokenService.GenerateAccessToken(user);
                var refreshToken = tokenService.GenerateRefreshToken();

                var userResponseModel = mapper.Map<UserResponseDto>(user);
                userResponseModel.AccessToken = jwt;
                userResponseModel.RefreshToken = refreshToken;
                userResponseModel.User = user;

                return Ok(userResponseModel);
            }

            user = await userManager.FindByEmailAsync(userInfo.Email);
            if(user != null)
            {
               await ctx.Entry(user)
                    .Reference(p => p.Profile)
                    .LoadAsync();

                user.RoleName = ctx.UserRoles
                        .Join(ctx.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                        .Where(r => r.UserRole.UserId == user.Id)
                        .FirstOrDefaultAsync().Result.Role.Name;


                await userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Facebook, userInfo.Id, "FacebookId"));

                var jwt = tokenService.GenerateAccessToken(user);
                var refreshToken = tokenService.GenerateRefreshToken();

                var userResponseModel = mapper.Map<UserResponseDto>(user);
                userResponseModel.RefreshToken = refreshToken;
                userResponseModel.AccessToken = jwt;
                userResponseModel.User = user;

                return Ok(userResponseModel);
            }

            user = new User();
            user.UserName = userInfo.Name.Replace(" ", "_");
            user.Email = userInfo.Email;
            user.NormalizedEmail = userManager.NormalizeEmail(userInfo.Email);
            user.NormalizedUserName = userManager.NormalizeName(userInfo.Name);
            
            user.Profile = new DAL.Models.Profile();
            user.Profile.Status = StatusProvider.NewArtist;
            user.Profile.Photo = userInfo.Picture.Data.Url;

            user.RefreshToken = tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);
            user.NormalizedEmail = userManager.NormalizeEmail(user.Email);
            user.NormalizedUserName = userManager.NormalizeName(user.UserName);

            var ideintityResult = await userManager.CreateAsync(user);

            ideintityResult = await userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Facebook, userInfo.Id, "FacebookId"));

            var roleResult = await userManager.AddToRoleAsync(user, "User");
            if (!roleResult.Succeeded)
                return BadRequest(roleResult.Errors);
            
            user.RoleName = ctx.UserRoles
                  .Join(ctx.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                  .Where(r => r.UserRole.UserId == user.Id)
                  .FirstOrDefaultAsync().Result.Role.Name;

            var jwtToken = tokenService.GenerateAccessToken(user);

            var userResponse = mapper.Map<UserResponseDto>(user);
            userResponse.AccessToken = jwtToken;
            userResponse.RefreshToken = user.RefreshToken;
            userResponse.User = user;

            return Ok(userResponse);
        }

        public async Task<IActionResult> RefreshToken(RefreshTokenDto model)
        {
            var user = await userRepository.GetUserByRefreshTokenAsync(model.RefreshToken);
                           
            if (user == null)
                return BadRequest("User not found");
            
            if(user.RefreshTokenExpiress >= DateTime.UtcNow)
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

        public async Task<IActionResult> Apple(AppleLogInDto model)
        {
            User user;
            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.RefreshToken = tokenService.GenerateRefreshToken();
                    user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

                    await userManager.UpdateAsync(user);

                    var jwtToken = tokenService.GenerateAccessToken(user);

                    var userResponseModel = mapper.Map<UserResponseDto>(user);
                    userResponseModel.RefreshToken = user.RefreshToken;
                    userResponseModel.AccessToken = jwtToken;
                    userResponseModel.User = user;

                    return Ok(userResponseModel);
                }

                user = await userManager.FindByLoginAsync(LogInProvider.Apple, model.Name);
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.Email = model.Email;
                    user.RefreshToken = tokenService.GenerateRefreshToken();
                    user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

                    await userManager.UpdateAsync(user);

                    var jwtToken = tokenService.GenerateAccessToken(user);

                    var userResponseResult = mapper.Map<UserResponseDto>(user);
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
                user.NormalizedEmail = userManager.NormalizeEmail(model.Email);
                user.NormalizedUserName = userManager.NormalizeName(model.Name);

                var profile = new DAL.Models.Profile
                {
                    User = user,
                    UserId = user.Id,
                    Status = StatusProvider.NewArtist,
                };
                user.Profile = profile;
                user.RefreshToken = tokenService.GenerateRefreshToken();
                user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

                var identity = await userManager.CreateAsync(user);
                if (!identity.Succeeded)
                    return BadRequest(identity.Errors.FirstOrDefault().Description);

                identity = await userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Apple, model.AppleId, "AppleId"));
                if (!identity.Succeeded)
                    return BadRequest(identity.Errors.FirstOrDefault().Description);

                var jwt = tokenService.GenerateAccessToken(user);

                var userResponse = mapper.Map<UserResponseDto>(user);
                userResponse.RefreshToken = user.RefreshToken;
                userResponse.AccessToken = jwt;
                userResponse.User = user;

                return Ok(userResponse);

            }
            return null;
        }

        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            var blobContainerClient = blobServiceClient.GetBlobContainerClient("templates");
            var blobClient = blobContainerClient.GetBlobClient("index.html");

            var uri = blobClient.Uri.AbsoluteUri;

            var html = (new WebClient()).DownloadString(uri);
            var passwordToken = await userManager.GeneratePasswordResetTokenAsync(user);
            string url = $"disco://disco.app/token/{passwordToken}";
            EmailConfirmationDto model = new EmailConfirmationDto();
            model.MessageHeader = "Email confirmation";
            model.MessageBody = html.Replace("[token]", passwordToken).Replace("[email]", user.Email);
            model.ToEmail = email;
            model.IsHtmlTemplate = true;

            emailService.EmailConfirmation(model);
            return Ok(passwordToken);
        }

        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            
            var identityResult = await userManager.ResetPasswordAsync(user, model.ConfirmationToken, model.Password);
            if (!identityResult.Succeeded)
                throw new Exception($"You have sum errors {identityResult.Errors}");
            return Ok(user);
        }

        public async Task<IActionResult> Google(IGoogleAuthProvider googleAuthProvider)
        {
            var googleResponse = await googleAuthService.GetUserData(googleAuthProvider);

            var email = googleResponse.EmailAddresses.FirstOrDefault();
            var userName = googleResponse.Names.FirstOrDefault();
            var photo = googleResponse.Photos.FirstOrDefault();

            var user = new User
            {
                UserName = userName.DisplayName,
                Email = email.Value,
                Profile = new DAL.Models.Profile
                {
                    Photo = photo.Url,
                    Status = StatusProvider.NewArtist
                }
            };

            await userManager.CreateAsync(user);

            var jwt = tokenService.GenerateAccessToken(user);
            var refreshToken = tokenService.GenerateRefreshToken();

            var userResponse = mapper.Map<UserResponseDto>(user);
            userResponse.RefreshToken = refreshToken;
            userResponse.AccessToken = jwt;
            userResponse.User = user;

            return Ok(userResponse);
        }
    }
}
