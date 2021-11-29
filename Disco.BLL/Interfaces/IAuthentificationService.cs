using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IAuthentificationService
    {
        Task<UserDTO> LogIn(LoginModel model);
        Task<UserDTO> Register(RegistrationModel model);
        Task<UserDTO> Facebook(string accessToken);
        public string GenerateJwtToken(User user);
    }
}
