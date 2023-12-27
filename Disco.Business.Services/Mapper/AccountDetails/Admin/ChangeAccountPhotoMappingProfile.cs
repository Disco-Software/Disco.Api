using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountPhoto;

namespace Disco.Business.Services.Mapper.AccountDetails.Admin
{
    public class ChangeAccountPhotoMappingProfile : Profile
    {
        public ChangeAccountPhotoMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Account, ChangeAccountPhotoResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x));
        }
    }
}
