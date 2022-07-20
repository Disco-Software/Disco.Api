using Disco.Business.Interfaces;
using Disco.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class ServicesConfigurator
    {
        public static void ConfigureServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IRegisterDeviceService, RegisterDeviceService>();

            serviceDescriptors.AddScoped<IAdminRoleService, AdminRoleService>();
            serviceDescriptors.AddScoped<IAdminUserService, AdminUserService>();

            serviceDescriptors.AddScoped<ITokenService, TokenService>();
            serviceDescriptors.AddScoped<IEmailService, EmailService>();
            serviceDescriptors.AddScoped<IGoogleAuthService, GoogleAuthService>();
            serviceDescriptors.AddScoped<IFacebookAuthService, FacebookAuthService>();
            serviceDescriptors.AddScoped<IAdminAuthenticationService, AdminAuthenticationService>();
            serviceDescriptors.AddScoped<IAuthenticationService, AuthenticationService>();

            serviceDescriptors.AddScoped<IImageService, ImageService>();
            serviceDescriptors.AddScoped<ISongService, SongService>();
            serviceDescriptors.AddScoped<IVideoService, VideoService>();
            serviceDescriptors.AddScoped<IPostService, PostService>();

            serviceDescriptors.AddScoped<IStoryImageService, StoryImageService>();
            serviceDescriptors.AddScoped<IStoryVideoService, StoryVideoService>();
            serviceDescriptors.AddScoped<IStoryService, StoryService>();

            serviceDescriptors.AddScoped<IFriendService, FriendService>();

            serviceDescriptors.AddScoped<IPushNotificationService, PushNotificationService>();
            serviceDescriptors.AddScoped<IProfileService, ProfileService>();
        }
    }
}
