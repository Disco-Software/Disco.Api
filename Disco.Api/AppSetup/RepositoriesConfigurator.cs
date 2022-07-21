using Disco.Domain.Interfaces;
using Disco.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class RepositoriesConfigurator
    {
        public static void ConfigureRepositories(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddTransient<IFriendRepository, FriendRepository>();
            serviceDescriptors.AddTransient<IImageRepository,ImageRepository>();
            serviceDescriptors.AddTransient<ILikeRepository,LikeRepository>();
            serviceDescriptors.AddTransient<IPostRepository,PostRepository>();
            serviceDescriptors.AddTransient<IProfileRepository,ProfileRepository>();
            serviceDescriptors.AddTransient<ISongRepository,SongRepository>();
            serviceDescriptors.AddTransient<IStoryImageRepository,StoryImageRepository>();
            serviceDescriptors.AddTransient<IStoryRepository,StoryRepository>();
            serviceDescriptors.AddTransient<IStoryVideoRepository,StoryVideoRepository>();
            serviceDescriptors.AddTransient<IUserRepository,UserRepository>();
            serviceDescriptors.AddTransient<IVideoRepository,VideoRepository>();
        }
    }
}
