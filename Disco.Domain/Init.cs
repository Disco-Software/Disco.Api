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
            .AddTransient<IFriendRepository, FriendRepository>()
            .AddTransient<IImageRepository, ImageRepository>()
            .AddTransient<ILikeRepository, LikeRepository>()
            .AddTransient<IPostRepository, PostRepository>()
            .AddTransient<IAccountRepository, ProfileRepository>()
            .AddTransient<ISongRepository, SongRepository>()
            .AddTransient<IStoryImageRepository, StoryImageRepository>()
            .AddTransient<IStoryRepository, StoryRepository>()
            .AddTransient<IStoryVideoRepository, StoryVideoRepository>()
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IVideoRepository, VideoRepository>()
            .AddTransient<IRoleRepository, RoleRepository>();
        }
    }
}
