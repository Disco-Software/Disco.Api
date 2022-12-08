using Disco.AdminPanel.Presentation.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Disco.AdminPanel.Presentation.Providers
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly IAccountService _accountService;
        private readonly ILocalStorageService _localStorageService;
        public AuthStateProvider(IAccountService accountService, ILocalStorageService localStorageService)
        {
            _accountService = accountService;
            _localStorageService = localStorageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorageService.GetStringAsync("accessToken");
            var tokenExpiers = await _localStorageService.GetStringAsync("accessTokenExpiers");
            var id = await _localStorageService.GetStringAsync("id");
            var role = await _localStorageService.GetStringAsync("role");

            if (token == null)
            {
                var anonymusIdentity = new ClaimsIdentity();
                var anonymusClaimPricipl = new ClaimsPrincipal(anonymusIdentity);
                return new AuthenticationState(anonymusClaimPricipl);
            }

            if (string.IsNullOrWhiteSpace(token) || DateTime.UtcNow > DateTime.UtcNow.AddMinutes(Convert.ToInt32(tokenExpiers)))
            {
                await _accountService.RefreshToken(new Models.Account.RefreshTokenModel 
                { 
                    AccessToken = await _localStorageService.GetStringAsync("accessToken"),
                    RefreshToken = await _localStorageService.GetStringAsync("refreshToken"),
                });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims);
            var claimPricipl = new ClaimsPrincipal(identity);
            
            return new AuthenticationState(claimPricipl);
        }
    }
}
