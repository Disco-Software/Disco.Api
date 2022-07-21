using Disco.Business.Dtos;
using Disco.Business.Dtos.Facebook;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IFacebookAuthService
    {
        Task<FacebookDto> GetUserInfo(string accessToken);
        Task<TokenValidationResponseModel> TokenValidation(string accessToken);
    }
}
