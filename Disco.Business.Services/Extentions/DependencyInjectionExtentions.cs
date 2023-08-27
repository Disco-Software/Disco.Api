using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Extentions
{
    public static class DependencyInjectionExtentions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            return services.AddScoped<ITokenService, TokenService>()
                .AddScoped<IAccountGroupService, AccountGroupService>()
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IAccountDetailsService, AccountDetailsService>()
                .AddScoped<IAccountPasswordService, AccountPasswordService>()
                .AddScoped<IPostService, PostService>()
                .AddScoped<IImageService, ImageService>()
                .AddScoped<ISongService, SongService>()
                .AddScoped<IVideoService, VideoService>()
                .AddScoped<IStoryService, StoryService>()
                .AddScoped<IStoryImageService, StoryImageService>()
                .AddScoped<IStoryVideoService, StoryVideoService>()
                .AddScoped<IConnectionService, ConnectionService>()
                .AddScoped<IGroupService, GroupService>()
                .AddScoped<IMessageService, MessageService>()
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<ICommentService, CommentService>()
                .AddScoped<IFollowerService, FollowerService>()
                .AddScoped<IPushNotificationService, PushNotificationService>()
                .AddScoped<ILikeService, LikeService>()
                .AddScoped<IAnalyticService, AnalyticService>()
                .AddScoped<IRoleService, RoleService>();
        }
    }
}
