using AutoMapper;
using Disco.Business.Interfaces.Dtos.TicketMessage.CreateImageMessage;

namespace Disco.Business.Services.Mapper.TicketMessage
{
    public class CreateImageMessageMappingProfile : Profile
    {
        public CreateImageMessageMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Ticket, Domain.Models.Models.TicketMessage>()
                .ForAllMembers(x => x.Ignore());
            CreateMap<string, Domain.Models.Models.TicketMessage>()
                .ForAllMembers(x => x.Ignore());
            CreateMap<Domain.Models.Models.TicketMessage, SendImageMessageResponseDto>()
                .ForAllMembers(x => x.Ignore());
        }
    }
}
