using Disco.AdminPanel.Models;

namespace Disco.AdminPanel.Interfaces
{
    public interface IAccountService
    {
        Task<UserResponseModel> Login(LogInModel model);
    }
}
