using AutoMapper;
using Disco.Business.Interfaces.Dtos.Group.User.GetAllGroupMessages;

namespace Disco.Business.Services.Mapper.Group
{
    public class GetAllGroupMessagesMappingProfile : Profile
    {
        public GetAllGroupMessagesMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Message, GetAllGroupMessagesResponseDto>()
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id))
                .ForMember(x => x.CreateDate, options => options.MapFrom(x => x.CreatedDate))
                .ForMember(x => x.Description, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.Account, options => options.MapFrom(x => x.Account));
        }
    }
}
