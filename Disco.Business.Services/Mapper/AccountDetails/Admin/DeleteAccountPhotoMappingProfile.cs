using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.DeleteAccountPhoto;

namespace Disco.Business.Services.Mapper.AccountDetails.Admin
{
    public class DeleteAccountPhotoMappingProfile : Profile
    {
        public DeleteAccountPhotoMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<AccountDto, DeleteAccountPhotoResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x));
        }
    }
}
