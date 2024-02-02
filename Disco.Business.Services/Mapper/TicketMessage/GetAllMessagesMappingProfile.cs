using AutoMapper;
using Disco.Business.Interfaces.Dtos.TicketMessage.GetAllMessages;

namespace Disco.Business.Services.Mapper.TicketMessage
{
    public class GetAllMessagesMappingProfile : Profile
    {
        public GetAllMessagesMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.TicketMessage, GetAllMessagesResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x.Account))
                .ForMember(x => x.Message, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.CreatedDate, options => options.MapFrom(x => x.CreatedDate))
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id));
        }
    }
}
