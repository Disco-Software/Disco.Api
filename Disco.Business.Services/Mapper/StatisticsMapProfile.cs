using AutoMapper;
using Disco.Business.Interfaces.Dtos.Statistics;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Mapper
{
    public class StatisticsMapProfile : Profile
    {
        public StatisticsMapProfile()
        {
            CreateMap<List<User>, StatisticsDto>()
                .ForMember(users => users.Users, options => options.MapFrom(users => users))
                .ForMember(users => users.UsersCount, options => options.MapFrom(users => users.Count))
                .ForMember(users => users.NewUsersCount, options => options.Ignore())
                .ForMember(users => users.RegisteredUsers, options => options.Ignore())
                .ForMember(users => users.PostsCount, options => options.Ignore())
                .ForMember(users => users.Posts, options => options.Ignore());

        }
    }
}
