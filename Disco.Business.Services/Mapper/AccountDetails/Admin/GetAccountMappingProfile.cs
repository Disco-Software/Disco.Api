using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAccount;

namespace Disco.Business.Services.Mapper.AccountDetails.Admin
{
    public class GetAccountMappingProfile : Profile
    {
        public GetAccountMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Account, GetAccountResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x));
        }
    }
}
