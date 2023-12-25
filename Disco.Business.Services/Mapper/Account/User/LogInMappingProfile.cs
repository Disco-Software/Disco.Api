using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account.User.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Mapper.Account.User
{
    public class LogInMappingProfile : Profile
    {
        public LogInMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, LogInResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x))
                .ForMember(x => x.AccessToken, options => options.Ignore())
                .ForMember(x => x.User, options => options.Ignore());
        }
    }
}
