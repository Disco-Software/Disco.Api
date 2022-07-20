using Disco.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class RepositoriesConfigurator
    {
        public static void ConfigureRepositories(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddTransient<FriendRepository>();
            serviceDescriptors.AddTransient<ImageRepository>();
            serviceDescriptors.AddTransient<LikeRepository>();
            serviceDescriptors.AddTransient<PostRepository>();
            serviceDescriptors.AddTransient<ProfileRepository>();
            serviceDescriptors.AddTransient<SongRepository>();
            serviceDescriptors.AddTransient<StoryImageRepository>();
            serviceDescriptors.AddTransient<StoryRepository>();
            serviceDescriptors.AddTransient<StoryVideoRepository>();
            serviceDescriptors.AddTransient<UserRepository>();
            serviceDescriptors.AddTransient<VideoRepository>();
        }
    }
}
