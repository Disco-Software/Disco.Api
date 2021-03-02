using Disco.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Login(LoginDTO login);
        Task<UserDTO> Register(RegisterDTO register);
    }
}
