using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.GetTicketsCount
{
    public class GetTicketsCountRequest : IRequest<int> { }
}
