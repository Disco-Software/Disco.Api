using AutoMapper;
using Disco.Business.Services.Mapper;
using Disco.Business.Services.Mapper.Account.Admin;
using Disco.Business.Services.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Business.Services.Extentions
{
    public static class AutoMapperExtentions
    {
        public static void AddAutoMapper(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton(conf => new MapperConfiguration(options =>
            {
                #region Admin
                options.AddProfile(new LogInMappingProfile());
                options.AddProfile(new RefreshTokenMappingProfile());
                #endregion

                options.AddProfile(new ErrorMapProfile());
            }).CreateMapper());
        }
    }
}
