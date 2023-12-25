using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.User.ChangePhoto;

namespace Disco.Business.Services.Mapper.AccountDetails.User
{
    public class ChangePhotoMappingProfile : Profile
    {
        public ChangePhotoMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, ChangePhotoResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x));
        }
    }
}
