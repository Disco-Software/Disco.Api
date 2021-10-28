using AutoMapper;
using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly ApiDbContext ctx;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;
        private readonly IFacebookAuthService facebookAuthService;

        public AuthentificationService(ApiDbContext _ctx,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            IFacebookAuthService _facebookAuthService,
            IMapper _mapper
            )
        {
            ctx = _ctx;
            userManager = _userManager;
            signInManager = _signInManager;
            facebookAuthService = _facebookAuthService;
            mapper = _mapper;
        }

        public async Task<UserDTO> Login(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var passwordResult = userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
                if (passwordResult == PasswordVerificationResult.Success)
                {
                    await signInManager.SignInAsync(user, false);
                    return new UserDTO { User = user, VarificationResult = "Success" };
                }
                else if (passwordResult == PasswordVerificationResult.Failed)
                    return new UserDTO { VarificationResult = "Wrong password" };
            }
            else if(user == null)
               return new UserDTO { VarificationResult = "Wrong email" };
            return new UserDTO { VarificationResult = "Network error" };
        }

        public async Task<UserDTO> Register(RegistrationModel userInfo)
        {
            var user = await ctx.Users
                .Where(e => e.Email == userInfo.Email)
                .FirstOrDefaultAsync();
            if (user != null)
            {
                GC.Collect();
                return new UserDTO { VarificationResult = "this user already created" };
            }
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
            return new UserDTO { User = model, VarificationResult = "Success"};
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
    }
}
