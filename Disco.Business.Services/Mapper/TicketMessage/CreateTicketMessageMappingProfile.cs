using AutoMapper;
using Disco.Business.Interfaces.Dtos.TicketMessage.CreateMessage;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Mapper.TicketMessage
{
    public class CreateTicketMessageMappingProfile : Profile
    {
        public CreateTicketMessageMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Ticket, Domain.Models.Models.TicketMessage>()
                .ForAllMembers(x => x.Ignore());
            CreateMap<string, Domain.Models.Models.TicketMessage>()
                .ForAllMembers(x => x.Ignore());
            CreateMap<Domain.Models.Models.TicketMessage, SendMessageResponseDto>()
                .ForAllMembers(x => x.Ignore());
        }
    }
}
