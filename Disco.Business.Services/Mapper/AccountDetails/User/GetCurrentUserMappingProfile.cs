using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.User.GetCurrentUser;

namespace Disco.Business.Services.Mapper.AccountDetails.User
{
    public class GetCurrentUserMappingProfile : Profile
    {
        public GetCurrentUserMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, GetCurrentUserResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x));
        }
    }
}
