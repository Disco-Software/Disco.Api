using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.SearchAccounts;

namespace Disco.Business.Services.Mapper.AccountDetails.Admin
{
    public class SearchAccountsMappingProfile : Profile
    {
        public SearchAccountsMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Account, SearchAccountsResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x));
        }
    }
}
