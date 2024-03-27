using Disco.Business.Interfaces.Dtos.TicketMessage.UpdateMessage;
using MediatR;
using System.Security.Claims;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.UpdateTicketMessage
{
    public class UpdateTicketMessageRequest : IRequest<UpdateTicketMessageResponseDto>
    {
        public UpdateTicketMessageRequest(
            ClaimsPrincipal claimsPrincipal,
            int id,
            string message)
        {
            Id = id;
            Message = message;
            ClaimsPrincipal = claimsPrincipal;
        }

        public ClaimsPrincipal ClaimsPrincipal { get; }
        public int Id { get; }
        public string Message { get; }
    }
}
