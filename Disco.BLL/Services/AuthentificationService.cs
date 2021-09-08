using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
        private readonly FacebookAuthService facebookAuthService;

        public AuthentificationService(ApiDbContext _ctx, UserManager<User> _userManager, SignInManager<User> _signInManager, FacebookAuthService _facebookAuthService)
        {
            ctx = _ctx;
            userManager = _userManager;
            signInManager = _signInManager;
            facebookAuthService = _facebookAuthService;
        }

        public async Task<UserDTO> Login(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var passwordResult = userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
                if (passwordResult == PasswordVerificationResult.Success)
                {
                    await signInManager.SignInAsync(user, true);
                    return new UserDTO { User = user, VarificationResult = "Success" };
                }
                else if (passwordResult == PasswordVerificationResult.Failed)
                    return new UserDTO { VarificationResult = "Wrong password" };
            }
            else if(user == null)
               return new UserDTO { VarificationResult = "Wrong email" };
            return new UserDTO { VarificationResult = "Network error" };
        }

        public async Task<UserDTO> Register(RegistrationModel model)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    user = new User
                    {
                        FullName = model.FullName,
                        UserName = model.UserName,
                        Email = model.Email,
                        PasswordHash = userManager.PasswordHasher.HashPassword(user,model.Password)
                    };
                    user.NormalizedEmail = userManager.NormalizeEmail(user.Email);
                    user.NormalizedUserName = userManager.NormalizeName(user.UserName);
                    await userManager.CreateAsync(user);
                    await ctx.Users.AddAsync(user);
                    await signInManager.CanSignInAsync(user);
                    await ctx.SaveChangesAsync();
                    return new UserDTO { User = user, VarificationResult = "Success" };
                }
                else if(user != null)
                    return new UserDTO { VarificationResult = "This user already created" };
                return new UserDTO { VarificationResult = "Network error" };
            }
            catch (Exception ex)
            {
                if (model.Email == null)
                    return new UserDTO { VarificationResult = "Email, mast have" };
                else if (model.FullName == null)
                    return new UserDTO { VarificationResult = "Full name, mast have" };
                else if (model.UserName == null)
                    return new UserDTO { VarificationResult = "User name, mast have" };
                else if (model.Password == null)
                    return new UserDTO { VarificationResult = "Password, mast have" };
                else if (model.ConfirmPassword == null)
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
