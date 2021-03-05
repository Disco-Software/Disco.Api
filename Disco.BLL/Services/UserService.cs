using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class UserService : IUserService
    {
        protected ApplicationDbContext ctx;
        protected ApplicationUserManager manager;
        public UserService(ApplicationUserManager userManager, ApplicationDbContext ctx)
        {
            this.ctx = ctx;
            this.manager = userManager;
        }

        public async Task<UserDTO> Login(LoginDTO login)
        {
            var user = await manager.FindByEmailAsync(login.Email);
            if(user != null)
            {
                var hasherResult = manager.PasswordHasher.VerifyHashedPassword((User)user, user.PasswordHash, login.Password);
                if(hasherResult == PasswordVerificationResult.Success)
                    return new UserDTO { User = user };
                else
                    return new UserDTO { VarificationResult = "Password is not correct" };
            }
            else
                return new UserDTO { VarificationResult = "Email not found" };
        }

        public async Task<UserDTO> Register(RegisterDTO register)
        {
            var user = new User
            {
                Email = register.Email
            };
            if (user is null)
                return new UserDTO { VarificationResult = "User is empty" };
            user.PasswordHash = manager.PasswordHasher.HashPassword(user, register.Password);
            await manager.CreateAsync(user);
            return new UserDTO { User = user };
        }
    }
}
