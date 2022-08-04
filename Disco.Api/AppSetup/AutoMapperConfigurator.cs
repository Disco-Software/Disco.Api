using AutoMapper;
using Disco.Business.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Api.AppSetup
{
    public static class AutoMapperConfigurator
    {
        public static void ConfigureAutoMapper(this IServiceCollection serviceDescriptors)
        {
            var mapperConfig = new MapperConfiguration(ms => ms.AddProfile(new MapProfile()));

            IMapper mapper = mapperConfig.CreateMapper();
            serviceDescriptors.AddSingleton(mapper);
        }
    }
}
