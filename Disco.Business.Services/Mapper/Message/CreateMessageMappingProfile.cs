using AutoMapper;
using Disco.Business.Interfaces.Dtos.Message.User.CreateMessage;

namespace Disco.Business.Services.Mapper.Message
{
    public class CreateMessageMappingProfile : Profile
    {
        public CreateMessageMappingProfile()
        {
            CreateMap<string, Domain.Models.Models.Message>()
                .ForMember(x => x.Description, options => options.MapFrom(x => x))
                .ForMember(x => x.CreatedDate, options => options.MapFrom(x => DateTime.UtcNow))
                .ForMember(x => x.Group, options => options.Ignore())
                .ForMember(x => x.GroupId, options => options.Ignore())
                .ForMember(x => x.Account, options => options.Ignore())
                .ForMember(x => x.AccountId, options => options.Ignore())
                .ForMember(x => x.Id, options => options.Ignore());

            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Message, CreateMessageResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x.Account))
                .ForMember(x => x.Description, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.CreatedDate, options => options.MapFrom(x => x.CreatedDate));
        }
    }
}
