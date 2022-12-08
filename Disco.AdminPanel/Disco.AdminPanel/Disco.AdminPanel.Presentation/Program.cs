using Disco.AdminPanel.Presentation;
using Disco.AdminPanel.Presentation.Interfaces;
using Disco.AdminPanel.Presentation.Providers;
using Disco.AdminPanel.Presentation.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

builder.Services.AddHttpClient();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<IUserService, UserService>();

await builder.Build().RunAsync();
