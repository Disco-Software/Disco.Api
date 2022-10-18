using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAccountPasswordService
    {
        Task ChengePasswordAsync(User user, string token, string newPassword);
        Task<PasswordVerificationResult> VerifyPasswordAsync(User user, string password);
        Task<string> GetPasswordConfirmationTokenAsync(User user);
        string AddPasswod(User user, string password);
    }           
}
