using AutoMapper;
using Disco.Business.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class AutoMapperConfigurator
    {
        public static void ConfigureAutoMapper(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AccountMapProfile());
                cfg.AddProfile(new PostMapProfile());
                cfg.AddProfile(new StoryMapProfile());
                cfg.AddProfile(new RoleMapProfile());
                cfg.AddProfile(new FollowerMapProfile());
            }).CreateMapper());

        }
    }
}
