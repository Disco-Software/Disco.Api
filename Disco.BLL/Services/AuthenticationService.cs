using AutoMapper;
using Azure.Storage.Blobs;
using Disco.BLL.Abstracts;
using Disco.BLL.Configurations;
using Disco.BLL.Constants;
using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.Apple;
using Disco.BLL.Models.Authentication;
using Disco.BLL.Models.EmailNotifications;
using Disco.BLL.Models.Google;
using Disco.BLL.Validatars;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using FluentValidation.Results;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AuthenticationService : UserRequestHandlerBase, IAuthenticationService
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

        public async Task<Models.Authentication.UserResponseModel> LogIn(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest("user not found");
           
            await ctx.Entry(user)
                .Reference(p => p.Profile)
                .LoadAsync();
            
            await ctx.Entry(user.Profile)
                .Collection(p => p.Posts)
                .LoadAsync();

            await ctx.Entry(user.Profile)
                .Collection(f => f.Friends)
                .LoadAsync();
                        
            var passwordVarification = userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (passwordVarification == PasswordVerificationResult.Failed)
                return BadRequest("Password is not valid");

            await signInManager.SignInAsync(user, true);
            var jwt = tokenService.GenerateAccessToken(user);
            var refreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

            await ctx.SaveChangesAsync();   

            return Ok(user, jwt, refreshToken);
        }

        public async Task<UserResponseModel> Register(RegistrationModel userInfo)
        {
            var validator = await RegistrationValidator
                .Create(userManager)
                .ValidateAsync(userInfo);
            
            var user = await userManager.FindByEmailAsync(userInfo.Email);

            if (user != null)
                return BadRequest("this user allready created");

            var userResult = mapper.Map<User>(userInfo);
            userResult.PasswordHash = userManager.PasswordHasher.HashPassword(userResult, userInfo.Password);
            userResult.Profile = new DAL.Entities.Profile { Status = StatusProvider.NewArtist };
            userResult.NormalizedEmail = userManager.NormalizeEmail(userResult.Email);
            userResult.NormalizedUserName = userManager.NormalizeName(userResult.UserName);
            userResult.RefreshToken = tokenService.GenerateRefreshToken();
            userResult.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

            var identityResult = await userManager.CreateAsync(userResult);
            if (!identityResult.Succeeded)
                return BadRequest("Password mast have a upper case lower case and 6 leters");
            await ctx.SaveChangesAsync();

            await signInManager.SignInAsync(userResult, true);
            var jwt = tokenService.GenerateAccessToken(user);

            return Ok(userResult, jwt);
        }

        public async Task<UserResponseModel> Facebook(string accessToken)
        {
            //var validation = await facebookAuthService.TokenValidation(accessToken);


            //if (!validation.IsValid)
            //    return new UserResponseModel { VarificationResult = "Facebook token is invalid" };

            var userInfo = await facebookAuthService.GetUserInfo(accessToken);

            var user = await userManager.FindByLoginAsync(LogInProvider.Facebook, userInfo.Id);

            if(user != null)
            {
                await ctx.Entry(user)
                        .Reference(p => p.Profile)
                        .LoadAsync();
               
                user.Email = userInfo.Email;
                user.UserName = userInfo.FirstName;
                user.Profile.Photo = userInfo.Picture.Data.Url;

               await userManager.UpdateAsync(user);

                var jwt = tokenService.GenerateAccessToken(user);
                var refreshToken = tokenService.GenerateRefreshToken();

                return Ok(user, jwt);
            }

            user = await userManager.FindByEmailAsync(userInfo.Email);
            if(user != null)
            {
               await userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Facebook, userInfo.Id, "FacebookId"));

                var jwt = tokenService.GenerateAccessToken(user);
                var refreshToken = tokenService.GenerateRefreshToken();

                return Ok(user, jwt, refreshToken);
            }


            user = new User
            {
                UserName = userInfo.FirstName,
                Email = string.IsNullOrWhiteSpace(userInfo.Email) ? userInfo.Email : userInfo.Name,
                PasswordHash = userManager.PasswordHasher.HashPassword(user, userInfo.Id),
                Profile = new DAL.Entities.Profile
                {
                    Photo = userInfo.Picture.Data.Url,
                    Status = StatusProvider.NewArtist,
                }
            };

            user.RefreshToken = tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);
            user.NormalizedEmail = userManager.NormalizeEmail(user.Email);
            user.NormalizedUserName = userManager.NormalizeName(user.UserName);
            
           var ideintityResult = await userManager.CreateAsync(user);

           ideintityResult = await userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Facebook, userInfo.Id, "FacebookId"));


            var jwtToken = tokenService.GenerateAccessToken(user);

            return Ok(user, jwtToken);
        }

        public async Task<UserResponseModel> RefreshToken(RefreshTokenRequestModel model)
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

                return Ok(user, jwtToken, user.RefreshToken);
            }

            var jwt = tokenService.GenerateAccessToken(user);

            return Ok(user, jwt, model.RefreshToken);
        }

        public async Task<UserResponseModel> Apple(AppleLogInModel model)
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

                    return Ok(user, jwtToken);
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

                    return Ok(user, jwtToken);
                }

                user = new User
                {
                    UserName = model.Name,

                    Email = model.Email
                };
                user.NormalizedEmail = userManager.NormalizeEmail(model.Email);
                user.NormalizedUserName = userManager.NormalizeName(model.Name);

                var profile = new DAL.Entities.Profile
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

                return Ok(user, jwt);

            }
            return null;
        }

        public async Task<string> ForgotPassword(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
                return "user not found";

            var blobContainerClient = blobServiceClient.GetBlobContainerClient("templates");
            var blobClient = blobContainerClient.GetBlobClient("index.html");

            var uri = blobClient.Uri.AbsoluteUri;

            var html = (new WebClient()).DownloadString(uri);
            var passwordToken = await userManager.GeneratePasswordResetTokenAsync(user);
            string url = $"disco://disco.app/token/{passwordToken}";
            EmailConfirmationModel model = new EmailConfirmationModel();
            model.MessageHeader = "Email confirmation";
            model.MessageBody = html.Replace("[token]", passwordToken).Replace("[email]", user.Email);
            model.ToEmail = email;
            model.IsHtmlTemplate = true;

            emailService.EmailConfirmation(model);
            return passwordToken;
        }

        public async Task<UserResponseModel> ResetPassword(ResetPasswordRequestModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            
            var identityResult = await userManager.ResetPasswordAsync(user, model.ConfirmationToken, model.Password);
            if (!identityResult.Succeeded)
                throw new Exception($"You have sum errors {identityResult.Errors}");
            return Ok(user);
        }

        public async Task<UserResponseModel> Google(IGoogleAuthProvider googleAuthProvider)
        {
            var googleResponse = await googleAuthService.GetUserData(googleAuthProvider);

            var email = googleResponse.EmailAddresses.FirstOrDefault();
            var userName = googleResponse.Names.FirstOrDefault();
            var photo = googleResponse.Photos.FirstOrDefault();

            var user = new User
            {
                UserName = userName.DisplayName,
                Email = email.Value,
                Profile = new DAL.Entities.Profile
                {
                    Photo = photo.Url,
                    Status = StatusProvider.NewArtist
                }
            };

            await userManager.CreateAsync(user);

            var jwt = tokenService.GenerateAccessToken(user);
            var refreshToken = tokenService.GenerateRefreshToken();

            return Ok(user, jwt,refreshToken);
        }
    }
}
