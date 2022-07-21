using Disco.Business.Dto;
using Disco.Business.Dto.Facebook;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IFacebookAuthService
    {
        Task<FacebookDto> GetUserInfo(string accessToken);
        Task<TokenValidationResponseModel> TokenValidation(string accessToken);
    }
}
