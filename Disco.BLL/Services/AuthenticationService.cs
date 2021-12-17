using AutoMapper;
using Disco.BLL.Abstracts;
using Disco.BLL.Configurations;
using Disco.BLL.Constants;
using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class AuthenticationService : UserDTOExtinsions, IAuthenticationService
    {
        private readonly ApiDbContext ctx;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;
        private readonly IFacebookAuthService facebookAuthService;
        private readonly IOptions<AuthenticationOptions> authenticationOptions;
        public AuthenticationService(ApiDbContext _ctx,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            IFacebookAuthService _facebookAuthService,
            IOptions<AuthenticationOptions> _authenticationOptions,
            IMapper _mapper)
        {
            ctx = _ctx;
            userManager = _userManager;
            signInManager = _signInManager;
            facebookAuthService = _facebookAuthService;
            mapper = _mapper;
            authenticationOptions = _authenticationOptions;
        }

        public async Task<UserDTO> LogIn(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest("user not found");

            var jwt = GenerateJwtToken(user);

            return Ok(user, jwt);
        }

        public async Task<UserDTO> Register(RegistrationModel userInfo)
        {
            var user = await userManager.FindByEmailAsync(userInfo.Email);
            if (user != null)
                return BadRequest("User already created");
           
            var userResult = mapper.Map<User>(userInfo);
            userResult.PasswordHash = userManager.PasswordHasher.HashPassword(userResult, userInfo.Password);
            userResult.Profile = new DAL.Entities.Profile { Status = "Music starter" };
            userResult.NormalizedEmail = userManager.NormalizeEmail(userResult.Email);
            userResult.NormalizedUserName = userManager.NormalizeName(userResult.UserName);

            await userManager.CreateAsync(userResult);
            await ctx.SaveChangesAsync();

            var jwt = GenerateJwtToken(userResult);

            return Ok(userResult, jwt);
        }

        public async Task<UserDTO> Facebook(string accessToken)
        {
            //var validation = await facebookAuthService.TokenValidation(accessToken);

            //if (!validation.IsValid)
            //    return new UserDTO { VarificationResult = "Facebook token is invalid" };

            var userInfo = await facebookAuthService.GetUserInfo(accessToken);

            var user = await userManager.FindByLoginAsync(LogInProviders.Facebook, userInfo.Id);

            await ctx.Entry(user)
                .Reference(p => p.Profile)
                .LoadAsync();

            if(user != null)
            {
                user.FullName = userInfo.Name;
                user.Email = userInfo.Email;
                user.UserName = userInfo.FirstName;
                user.Profile.Photo = userInfo.Picture.Data.Url;

               await userManager.UpdateAsync(user);

                var jwt = GenerateJwtToken(user);

                return Ok(user, jwt);
            }

            user = await userManager.FindByEmailAsync(userInfo.Email);
            if(user != null)
            {
               await userManager.AddLoginAsync(user, new UserLoginInfo(LogInProviders.Facebook, userInfo.Id, "FacebookId"));

                var jwt = GenerateJwtToken(user);

                return Ok(user, jwt);
            }


            user = new User
            {
                UserName = userInfo.FirstName,
                FullName = userInfo.Name,
                Email = string.IsNullOrWhiteSpace(userInfo.Email) ? userInfo.Email : userInfo.Name,
                PasswordHash =  userManager.PasswordHasher.HashPassword(user, userInfo.Id),
                Profile = new DAL.Entities.Profile
                {
                    Photo = userInfo.Picture.Data.Url,
                    Status = "Music starter"
                }
            };
            user.NormalizedEmail = userManager.NormalizeEmail(user.Email);
            user.NormalizedUserName = userManager.NormalizeName(user.UserName);
            
           var ideintityResult = await userManager.CreateAsync(user);

           ideintityResult = await userManager.AddLoginAsync(user, new UserLoginInfo(LogInProviders.Facebook, userInfo.Id, "FacebookId"));


            var jwtToken = GenerateJwtToken(user);

            return Ok(user, jwtToken);
        }

        public string GenerateJwtToken(User user)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                authenticationOptions.Value.Issuer,
                authenticationOptions.Value.Audience,
                new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) },
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(authenticationOptions.Value.ExpiresAfterMitutes),
                new SigningCredentials(
                        new SymmetricSecurityKey(authenticationOptions.Value.SigningKeyBytes),
                        SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        public async Task<UserDTO> RefreshToken(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
                return BadRequest("User not found");

            var jwt = GenerateJwtToken(user);

            return Ok(user, jwt);
        }

        public async Task<UserDTO> Apple(AppleLogInModel model)
        {
            User user;
            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.FullName = model.Name;

                    await userManager.UpdateAsync(user);

                    var jwtToken = GenerateJwtToken(user);

                    return Ok(user, jwtToken);
                }

                user = await userManager.FindByLoginAsync(LogInProviders.Apple, model.AppleId);
                if (user != null)
                {
                    user.FullName = model.Name;
                    user.UserName = model.Name;
                    user.Email = model.Email;

                    await userManager.UpdateAsync(user);

                    var jwtToken = GenerateJwtToken(user);

                    return Ok(user, jwtToken);
                }

                user = new User
                {
                    UserName = model.Name,
                    FullName = model.Name,
                    Email = model.Email
                };
                user.NormalizedEmail = userManager.NormalizeEmail(model.Email);
                user.NormalizedUserName = userManager.NormalizeName(model.Name);

                var identity = await userManager.CreateAsync(user);

                identity = await userManager.AddLoginAsync(user, new UserLoginInfo(LogInProviders.Apple, model.AppleId, "AppleId"));

                var jwt = GenerateJwtToken(user);

                return Ok(user, jwt);

            }
            return null;
        }
    }
}
