using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAllAccounts;

namespace Disco.Business.Services.Mapper.AccountDetails.Admin
{
    public class GetAllAccountsMappingProfile : Profile
    {
        public GetAllAccountsMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<AccountDto, GetAllAccountsResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x));
        }
    }
}
