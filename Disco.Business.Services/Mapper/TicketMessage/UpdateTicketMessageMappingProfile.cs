using AutoMapper;
using Disco.Business.Interfaces.Dtos.TicketMessage.UpdateMessage;

namespace Disco.Business.Services.Mapper.TicketMessage
{
    public class UpdateTicketMessageMappingProfile : Profile
    {
        public UpdateTicketMessageMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.TicketMessage, UpdateTicketMessageResponseDto>()
                .ForMember(x => x.Message, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.Created, options => options.MapFrom(x => x.CreatedDate))
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id));
        }
    }
}
