using AutoMapper;
using Disco.Business.Interfaces.Dtos.Ticket.User.CreateTicket;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Mapper.Ticket.User
{
    public class CreateTicketMappingProfile : Profile
    {
        public CreateTicketMappingProfile()
        {
            CreateMap<CreateTicketRequestDto, Domain.Models.Models.Ticket>()
                .ForMember(x => x.Status, options => options.Ignore())
                .ForMember(x => x.TicketMessages, options => options.MapFrom(x => new List<TicketMessage>()))
                .ForMember(x => x.Description, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.Priority, options => options.Ignore())
                .ForMember(x => x.Administrators, options => options.MapFrom(x => new List<TicketAccount>()))
                .ForMember(x => x.Owner, options => options.Ignore())
                .ForMember(x => x.OwnerId, options => options.Ignore());
        }
    }
}
