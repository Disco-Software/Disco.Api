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
            try
            {
                var user = await userManager.FindByEmailAsync(userInfo.Email);
                if (user == null)
                {
                    var model = mapper.Map<User>(userInfo);
                    model.NormalizedEmail = userManager.NormalizeEmail(model.Email);
                    model.NormalizedUserName = userManager.NormalizeName(model.UserName);
                    await userManager.CreateAsync(model);
                    //await ctx.Users.AddAsync(model);
                    await signInManager.CanSignInAsync(model);
                    await ctx.SaveChangesAsync();
                    return new UserDTO { User = model, VarificationResult = "Success" };
                }
                else if(user != null)
                    return new UserDTO { VarificationResult = "This user already created" };
                return new UserDTO { VarificationResult = "Network error" };
            }
            catch (Exception ex)
            {
                if (userInfo.Email == null)
                    return new UserDTO { VarificationResult = "Email, mast have" };
                else if (userInfo.FullName == null)
                    return new UserDTO { VarificationResult = "Full name, mast have" };
                else if (userInfo.UserName == null)
                    return new UserDTO { VarificationResult = "User name, mast have" };
                else if (userInfo.Password == null)
                    return new UserDTO { VarificationResult = "Password, mast have" };
                else if (userInfo.ConfirmPassword == null)
                    return new UserDTO { VarificationResult = "Confirm your password" };
                return new UserDTO { VarificationResult = ex.ToString() };
            }
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
