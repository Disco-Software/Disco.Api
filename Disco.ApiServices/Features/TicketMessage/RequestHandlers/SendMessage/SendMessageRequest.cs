using Disco.Business.Interfaces.Dtos.TicketMessage.CreateMessage;
using MediatR;
using System.Security.Claims;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.SendMessage
{
    public class SendMessageRequest : IRequest<SendMessageResponseDto>
    {
        public SendMessageRequest(
            string message,
            int ticketId,
            string ticketName,
            ClaimsPrincipal user)
        {
            Message = message;
            TicketId = ticketId;
            TicketName = ticketName;
            User = user;
        }

        public string TicketName {  get; }
        public int TicketId {  get; }
        public string Message { get; }
        public ClaimsPrincipal User { get; }
    }
}
