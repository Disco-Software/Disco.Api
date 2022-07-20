using Disco.BLL.Dto;
using Disco.BLL.Dto;
using Disco.BLL.Dto.Facebook;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IFacebookAuthService
    {
        Task<FacebookDto> GetUserInfo(string accessToken);
        Task<TokenValidationResponseModel> TokenValidation(string accessToken);
    }
}
