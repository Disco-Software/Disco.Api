using Disco.Api.Middlewares;
using Disco.Business.Interfaces;
using Disco.Business.Services;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class WebSocketRequestConfigurator
    {
        public static IApplicationBuilder MapWebSocketRequest(
            this IApplicationBuilder app,
            PathString path)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager= (UserManager<User>)scope.ServiceProvider.GetService(typeof(UserManager<User>));
                var userService = (IUserService)scope.ServiceProvider.GetRequiredService(typeof(IUserService));
                var likeSocketService = (ILikeSocketService)scope.ServiceProvider.GetRequiredService(typeof(ILikeSocketService));
                var likeService = (ILikeService)scope.ServiceProvider.GetRequiredService(typeof(ILikeService));
                return app.Map(path, (_app) => _app.UseMiddleware<WebSocketMiddleware>(likeSocketService, likeService, userService));
            }

        }
    }
}
