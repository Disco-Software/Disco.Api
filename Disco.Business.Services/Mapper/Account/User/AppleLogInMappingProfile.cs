using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account.User.Apple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Mapper.Account.User
{
    public class AppleLogInMappingProfile : Profile
    {
        public AppleLogInMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, AppleLogInResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x))
                .ForMember(x => x.AccessToken, options => options.Ignore())
                .ForMember(x => x.RefreshToken, options => options.Ignore());
        }
    }
}
