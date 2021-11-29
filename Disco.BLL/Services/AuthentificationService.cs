using AutoMapper;
using Disco.BLL.Abstracts;
using Disco.BLL.Configurations;
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
    public class AuthentificationService : UserDTOExtinsions, IAuthentificationService
    {
        private readonly ApiDbContext ctx;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;
        private readonly IFacebookAuthService facebookAuthService;
        private readonly IOptions<AuthenticationOptions> authenticationOptions;
        public AuthentificationService(ApiDbContext _ctx,
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
            var user = await ctx.Users
                .Where(e => e.Email == userInfo.Email)
                .FirstOrDefaultAsync();
            if (user != null)
                return BadRequest("user allready created");
            var model = mapper.Map<User>(userInfo);
            model.NormalizedEmail = userManager.NormalizeEmail(userInfo.Email);
            model.NormalizedUserName = userManager.NormalizeName(userInfo.UserName);
            model.PasswordHash = userManager.PasswordHasher.HashPassword(model,userInfo.Password);
            model.Profile = new DAL.Entities.Profile
            {
                Status = "New artist",
                UserId = model.Id,
                User = model
            };
            ctx.Profiles.Add(model.Profile);
            await userManager.CreateAsync(model);
            ctx.SaveChanges();
            return Ok(user, "success");
        }

        public async Task<UserDTO> Facebook(string accessToken)
        {
            var validation = await facebookAuthService.TokenValidation(accessToken);

            if (!validation.IsValid)
                return new UserDTO { VarificationResult = "Facebook token is invalid" };

            var userInfo = await facebookAuthService.GetUserInfo(accessToken);

            var user = await userManager.FindByEmailAsync(userInfo.User.Email);

            if(user == null)
            {
                var registration = new RegistrationModel()
                {
                    FullName = userInfo.User.FullName,
                    UserName = userInfo.User.UserName,
                    Email = userInfo.User.Email,
                };
                if (registration.Password == registration.ConfirmPassword)
                {
                    user = new User
                    {
                        FullName = registration.FullName,
                        UserName = registration.UserName,
                        Email = registration.Email,
                    };
                    user.PasswordHash = userManager.PasswordHasher.HashPassword(user, registration.Password);
                    await userManager.CreateAsync(user);
                    await ctx.Users.AddAsync(user);
                    await ctx.SaveChangesAsync();
                    await signInManager.CanSignInAsync(user);
                    return new UserDTO { User = user, VarificationResult = "Success" };
                }
                else
                    return new UserDTO
                    {
                        VarificationResult = "Password and password repeat are not equal"
                    };
            }
            else
                return new UserDTO { User = user, VarificationResult = "Success" };
        }

        public string GenerateJwtToken(User user)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                authenticationOptions.Value.Issure,
                authenticationOptions.Value.Audience,
                new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) },
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(authenticationOptions.Value.ExpiresAfterDays),
                new SigningCredentials(
                        new SymmetricSecurityKey(authenticationOptions.Value.SigningKeyBytes),
                        SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
