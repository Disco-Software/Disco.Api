using Disco.Business.Interfaces.Dtos.TicketMessage.UpdateMessage;
using MediatR;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.UpdateTicketMessage
{
    public class UpdateTicketMessageRequest : IRequest<UpdateTicketMessageResponseDto>
    {
        public UpdateTicketMessageRequest(
            int id,
            string message)
        {
            Id = id;
            Message = message;
        }

        public int Id { get; }
        public string Message { get; }
    }
}
