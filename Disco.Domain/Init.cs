using Disco.Domain.Interfaces;
using Disco.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Domain
{
    public static class InitRepositories
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection serviceDescriptors)
        {
            return serviceDescriptors
            .AddTransient<IAccountStatusRepository, AccountStatusRepository>()
            .AddTransient<IFollowerRepository, FollowerRepository>()
            .AddTransient<IImageRepository, ImageRepository>()
            .AddTransient<ILikeRepository, LikeRepository>()
            .AddTransient<CommentRepository>()
            .AddTransient<IPostRepository, PostRepository>()
            .AddTransient<IAccountRepository, AccountRepository>()
            .AddTransient<ISongRepository, SongRepository>()
            .AddTransient<IStoryImageRepository, StoryImageRepository>()
            .AddTransient<IStoryRepository, StoryRepository>()
            .AddTransient<IStoryVideoRepository, StoryVideoRepository>()
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IVideoRepository, VideoRepository>()
            .AddTransient<IRoleRepository, RoleRepository>()
            .AddTransient<IGroupRepository, GroupRepository>()
            .AddTransient<IMessageRepository, MessageRepository>()
            .AddTransient<IConnectionRepository, ConnectionRepository>();
        }
    }
}
