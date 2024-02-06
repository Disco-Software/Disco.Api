using AutoMapper;
using Disco.Business.Interfaces.Dtos.Ticket.Admin.SearchTickets;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Mapper.Ticket.Admin
{
    public class SearchTicketsMappingProfile : Profile
    {
        public SearchTicketsMappingProfile()
        {
            CreateMap<OwnerSummary, AccountDto>();

            CreateMap<TicketSummary, SearchTicketsResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner));
        }
    }
}
