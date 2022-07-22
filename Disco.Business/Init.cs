using Disco.Business.Interfaces;
using Disco.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Business
{
    public static class InitBusiness
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection serviceDescriptors)
        {
            return serviceDescriptors
                .AddScoped<IRegisterDeviceService, RegisterDeviceService>()
                .AddScoped<IAdminRoleService, AdminRoleService>()
                .AddScoped<IAdminUserService, AdminUserService>()
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<IGoogleAuthService, GoogleAuthService>()
                .AddScoped<IFacebookAuthService, FacebookAuthService>()
                .AddScoped<IAdminAuthenticationService, AdminAuthenticationService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IImageService, ImageService>()
                .AddScoped<ISongService, SongService>()
                .AddScoped<IVideoService, VideoService>()
                .AddScoped<IPostService, PostService>()
                .AddScoped<IStoryImageService, StoryImageService>()
                .AddScoped<IStoryVideoService, StoryVideoService>()
                .AddScoped<IStoryService, StoryService>()
                .AddScoped<IFriendService, FriendService>()
                .AddScoped<IPushNotificationService, PushNotificationService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IProfileService, ProfileService>();
        }
    }
}
