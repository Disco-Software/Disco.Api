using Disco.Business.Interfaces.Dtos.TicketMessage.CreateMessage;
using MediatR;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.SendMessage
{
    public class SendMessageRequest : IRequest<SendMessageResponseDto>
    {
        public SendMessageRequest(
            string message,
            int ticketId,
            string ticketName)
        {
            Message = message;
            TicketId = ticketId;
            TicketName = ticketName;
        }

        public string TicketName {  get; }
        public int TicketId {  get; }
        public string Message { get; }
    }
}
