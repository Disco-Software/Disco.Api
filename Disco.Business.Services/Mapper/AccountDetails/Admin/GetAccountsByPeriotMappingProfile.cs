using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAccountsByPeriot;

namespace Disco.Business.Services.Mapper.AccountDetails.Admin
{
    public class GetAccountsByPeriotMappingProfile : Profile
    {
        public GetAccountsByPeriotMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, GetAccountsByPeriotResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x));
        }
    }
}
