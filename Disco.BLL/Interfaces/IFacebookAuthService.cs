using Disco.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IFacebookAuthService
    {
        Task<UserDTO> GetUserInfo(string accessToken);
        Task<TokenValidationDTO> TokenValidation(string accessToken);
    }
}
