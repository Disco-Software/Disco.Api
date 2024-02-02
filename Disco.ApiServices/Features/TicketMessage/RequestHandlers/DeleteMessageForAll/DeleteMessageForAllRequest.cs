using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.DeleteMessageForAll
{
    public class DeleteMessageForAllRequest : IRequest
    {
        public DeleteMessageForAllRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
