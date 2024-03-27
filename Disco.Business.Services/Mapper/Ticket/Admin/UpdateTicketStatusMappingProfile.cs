using AutoMapper;
using Disco.Business.Interfaces.Dtos.Ticket.Admin.UpdateTicketStatus;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Mapper.Ticket.Admin
{
    public class UpdateTicketStatusMappingProfile : Profile
    {
        public UpdateTicketStatusMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountDto>().PreserveReferences();
            CreateMap<Domain.Models.Models.User, AccountDto>()
                .ForMember(x => x.UserName, options => options.MapFrom(x => x.UserName));

            CreateMap<Domain.Models.Models.Ticket, UpdateTicketStatusResponseDto>()
                .ForMember(x => x.CreatedDate, options => options.MapFrom(x => x.ClosedDate))
                .ForMember(x => x.Status, options => options.MapFrom(x => x.Status.Name))
                .ForMember(x => x.Priority, options => options.MapFrom(x => x.Priority.Name))
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id))
                .ForMember(x => x.Owner, options => options.MapFrom(x => x.Owner));            
        }
    }
}
