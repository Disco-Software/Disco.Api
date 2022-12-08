using Disco.AdminPanel.Presentation.Models.Account;

namespace Disco.AdminPanel.Presentation.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersByRange(int days, string token);
    }
}
