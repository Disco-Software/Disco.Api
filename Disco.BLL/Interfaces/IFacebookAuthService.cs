using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.BLL.Models.Facebook;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IFacebookAuthService
    {
        Task<FacebookModel> GetUserInfo(string accessToken);
        Task<TokenValidationResponseModel> TokenValidation(string accessToken);
    }
}
