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
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IAccountDetailsService, AccountDetailsService>()
                .AddScoped<IAccountPasswordService, AccountPasswordService>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IStatisticsService, StatisticsService>()
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<IFacebookAuthService, FacebookAuthService>()
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IImageService, ImageService>()
                .AddScoped<ISongService, SongService>()
                .AddScoped<IAudDService, AudDService>()
                .AddScoped<IVideoService, VideoService>()
                .AddScoped<ILikeService, LikeService>()
                .AddScoped<ICommentService, CommentService>()
                .AddScoped<IPostService, PostService>()
                .AddScoped<IStoryImageService, StoryImageService>()
                .AddScoped<IStoryVideoService, StoryVideoService>()
                .AddScoped<IStoryService, StoryService>()
                .AddScoped<IFollowerService, FollowerService>()
                .AddScoped<IPushNotificationService, PushNotificationService>()
                .AddScoped<IConnectionService, ConnectionService>()
                .AddScoped<IGroupService, GroupService>()
                .AddScoped<IAccountGroupService, AccountGroupService>()
                .AddScoped<IMessageService, MessageService>();
        }
    }
}
