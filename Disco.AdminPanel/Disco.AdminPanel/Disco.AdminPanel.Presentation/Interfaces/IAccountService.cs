using Disco.AdminPanel.Presentation.Models.Account;
using Disco.AdminPanel.Presentation.ViewModels;

namespace Disco.AdminPanel.Presentation.Interfaces
{
    public interface IAccountService
    {
        Task<UserResponseModel> LoginAsync(LoginViewModel model);
        Task<UserResponseModel> RefreshToken(RefreshTokenModel model);
    }
}
