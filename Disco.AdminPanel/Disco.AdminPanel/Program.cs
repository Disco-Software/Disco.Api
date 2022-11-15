using Blazored.Modal;
using Disco.AdminPanel;
using Disco.AdminPanel.Interfaces;
using Disco.AdminPanel.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();
