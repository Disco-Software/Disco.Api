using Disco.AdminPanel.Presentation.Interfaces;
using Disco.AdminPanel.Presentation.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Disco.AdminPanel.Presentation.Pages.Account.LogIn
{
    public class LogInComponent : ComponentBase
    {
        [Inject] public IAccountService AccountService { get; set; }
        [Inject] public ILocalStorageService LocalStorageService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        public LoginViewModel Model { get; set; }

        public LogInComponent()
        {
            Model = new LoginViewModel();
        }

        public async Task OnForgotPassword()
        {

        }

        public async Task OnFormSubmit()
        {
            var userResponseModel = await AccountService.LoginAsync(Model);

            await LocalStorageService.SetStringAsync("accessToken", userResponseModel.AccessToken);
            await LocalStorageService.SetStringAsync("refreshToken", userResponseModel.RefreshToken);
            await LocalStorageService.SetStringAsync("accessTokenExpiers", userResponseModel.AccessTokenExpirce.ToString());
            await LocalStorageService.SetStringAsync("role", userResponseModel.User.RoleName);

            NavigationManager.NavigateTo("/dashbord");
        }
    }
}
