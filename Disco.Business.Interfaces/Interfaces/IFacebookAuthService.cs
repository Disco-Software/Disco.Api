using Disco.Business.Interfaces.Dtos.Facebook;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IFacebookAuthService
    {
        Task<FacebookDto> GetUserInfo(string accessToken);
        Task<TokenValidationResponseModel> TokenValidation(string accessToken);
    }
}
