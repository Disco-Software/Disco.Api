using Disco.Business.Interfaces.Dtos.TicketMessage.CreateImageMessage;
using MediatR;
using System.Security.Claims;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.SendImageMessage
{
    public class SendImageMessageRequest : IRequest<SendImageMessageResponseDto>
    {
        public SendImageMessageRequest(
            string[] images,
            string? message,
            int ticketId,
            string ticketName,
            ClaimsPrincipal user)
        {
            Images = images;
            Message = message;
            TicketId = ticketId;
            TicketName = ticketName;
            User = user;
        }

        public string TicketName { get; }
        public int TicketId { get; }
        public ClaimsPrincipal User { get; }
        public string[] Images { get; }
        public string? Message { get; }
    }
}
