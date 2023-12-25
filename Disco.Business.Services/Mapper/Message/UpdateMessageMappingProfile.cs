using AutoMapper;
using Disco.Business.Interfaces.Dtos.Message.User.UpdateMessage;

namespace Disco.Business.Services.Mapper.Message
{
    public class UpdateMessageMappingProfile : Profile
    {
        public UpdateMessageMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Message, UpdateMessageResponseDto>()
                .ForMember(x => x.CreatedDate, options => options.MapFrom(x => x.CreatedDate))
                .ForMember(x => x.Description, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.Account, options => options.MapFrom(x => x.Account));
        }
    }
}
