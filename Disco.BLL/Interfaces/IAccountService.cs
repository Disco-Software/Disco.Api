using Disco.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<UserDTO> Login(LoginDTO login);
        Task<UserDTO> Register(RegisterDTO register);
        Task<ForgotPasswordResultDTO> ForgotPassword(ForgotPasswordDTO forgotPassword);
    }
}
