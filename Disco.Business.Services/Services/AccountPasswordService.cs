using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Utils.Exceptions;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace Disco.Business.Services.Services
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
            if (!response.Succeeded)
            {
                throw new NullReferenceException();
            }
        }

        public async Task ChangeSelectedUserPasswordAsynnc(User user, string newPassword)
        {
            var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var identityResult = await _userManager.ResetPasswordAsync(user, passwordResetToken, newPassword);
            if (identityResult.Errors.Count() > 0)
            {
                var errors = new Dictionary<string, string>();
                
                foreach (var error in identityResult.Errors)
                    errors.Add(error.Code, error.Description);

                throw new InvalidPasswordException(errors);
            }
        }

        public async Task<PasswordVerificationResult> VerifyPasswordAsync(User user, string password)
        {
            var passwordRespnose = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash ?? "", password);

            switch (passwordRespnose)
            {
                case PasswordVerificationResult.Failed:
                    return PasswordVerificationResult.Failed;
                case PasswordVerificationResult.Success:
                    return PasswordVerificationResult.Success;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    return PasswordVerificationResult.SuccessRehashNeeded;
                default: 
                    return PasswordVerificationResult.Failed;
            }
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

        public async Task ChangePasswordAsync(User user, string newPassword)
        {
            var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var identityResult = await _userManager.ResetPasswordAsync(user, passwordResetToken, newPassword);
            if(identityResult.Errors.Count() > 0)
            {
                var errors = new Dictionary<string, string>();

                foreach (var error in identityResult.Errors)
                    errors.Add(error.Code, error.Description);

                throw new PasswordRecoveryException(errors);
            }
        }
    }
}
