using AutoMapper;
using Disco.Business.Interfaces.Dtos.Ticket.Admin.GetAllTickets;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Mapper.Ticket.Admin
{
    public class GetAllTicketsMappingProfile : Profile
    {
        public GetAllTicketsMappingProfile()
        {
            CreateMap<OwnerSummary, AccountDto>().PreserveReferences();

            CreateMap<TicketSummary, GetAllTicketsResponseDto>()
                .ForMember(x => x.Title, options => options.MapFrom(x => x.Title))
                .ForMember(x => x.Description, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.CreatedDate, options => options.MapFrom(x => x.CreatedDate))
                .ForMember(x => x.CreatedDate, options => options.MapFrom(x => x.CreatedDate))
                .ForMember(x => x.Status, options => options.MapFrom(x => x.Status))
                .ForMember(x => x.Priority, options => options.MapFrom(x => x.Priority))
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id))
                .ForMember(x => x.Owner, options => options.MapFrom(x => x.Owner));
        }
    }
}
