using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class AccountPasswordService : IAccountPasswordService
    {
        private readonly UserManager<User> _userManager;

        public AccountPasswordService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task ChengePasswordAsync(User user, string token, string newPassword)
        {
            var response = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (response == null || response.Errors.Count() > 0)
            {
                throw new NullReferenceException();
            }
        }

        public async Task<PasswordVerificationResult> VerifyPasswordAsync(User user, string password)
        {
            var passwordRespnose = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if(passwordRespnose != PasswordVerificationResult.Success)
            {
                return PasswordVerificationResult.Failed;
            }

            return passwordRespnose;
        }

        public async Task<string> GetPasswordConfirmationTokenAsync(User user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public string AddPasswod(User user, string password)
        {
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            return user.PasswordHash;
        }
    }
}
