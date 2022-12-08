using Disco.AdminPanel.Presentation.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace Disco.AdminPanel.Presentation.Pages.Users.List
{
    [Authorize]
    public class UsersListModel : ComponentBase
    {
        [Inject] public IUserService UserService { get; set; }
        [Inject] public ILocalStorageService LocalStorageService { get; set; }

        public List<Models.Account.User> Users { get; set; }

        public UsersListModel()
        {
            Users = new List<Models.Account.User>();
        }

        protected override async void OnInitialized()
        {
            base.OnInitialized();

            var token = await LocalStorageService.GetStringAsync("accessToken");

            var response = await UserService.GetAllUsersByRange(365, token);
            Users = response.ToList();
        }
    }
}
