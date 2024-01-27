using Disco.Domain.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Extentions
{
    public static class DependencyInjectionExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient<IAccountRepository, AccountRepository>()
                .AddTransient<IAccountStatusRepository, AccountStatusRepository>()
                .AddTransient<IAccountGroupRepository, AccountGroupRepository>()
                .AddTransient<IConnectionRepository, ConnectionRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<IFollowerRepository, FollowerRepository>()
                .AddTransient<IGroupRepository, GroupRepository>()
                .AddTransient<IImageRepository, ImageRepository>()
                .AddTransient<ILikeRepository, LikeRepository>()
                .AddTransient<IMessageRepository, MessageRepository>()
                .AddTransient<INotificationRepository, NotificationRepository>()
                .AddTransient<IPostRepository, PostRepository>()
                .AddTransient<IRoleRepository, RoleRepository>()
                .AddTransient<ISongRepository, SongRepository>()
                .AddTransient<IStoryImageRepository, StoryImageRepository>()
                .AddTransient<IStoryRepository, StoryRepository>()
                .AddTransient<IStoryVideoRepository, StoryVideoRepository>()
                .AddTransient<ITicketRepository, TicketRepository>()
                .AddTransient<ITicketAccountRepository, TicketAccountRepository>()
                .AddTransient<ITicketMessageRepository, TicketMessageRepository>()
                .AddTransient<ITicketPriorityRepository, TicketPriorityRepository>()
                .AddTransient<ITicketStatusRepository, TicketStatusRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IVideoRepository, VideoRepository>();
        }
    }
}
