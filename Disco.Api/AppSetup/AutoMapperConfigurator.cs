using AutoMapper;
using Disco.Business.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class AutoMapperConfigurator
    {
        public static void ConfigureAutoMapper(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton(conf => new MapperConfiguration(options =>
            {
                options.AddProfile(new AccountMapProfile());
                options.AddProfile(new GlobalSearchMapProfile());
                options.AddProfile(new PostMapProfile());
                options.AddProfile(new StoryMapProfile());
                options.AddProfile(new RoleMapProfile());
                options.AddProfile(new FollowerMapProfile());
                options.AddProfile(new MessageMapProfile());
                options.AddProfile(new CommentMapProfile());
            }).CreateMapper());
        }
    }
}
