using AutoMapper;
using Disco.Business.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Tests.Mock
{
    public class MockedAutoMapper
    {
        public static IMapper MockAutoMapper()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new AccountMapProfile());
                config.AddProfile(new CommentMapProfile());
                config.AddProfile(new FollowerMapProfile());
                config.AddProfile(new GlobalSearchMapProfile());
                config.AddProfile(new GroupMapProfile());
                config.AddProfile(new PostMapProfile());
                config.AddProfile(new RoleMapProfile());
                config.AddProfile(new StoryMapProfile());
            });

            var mapper = mapperConfig.CreateMapper();

            return mapper;
        }
    }
}
