using MediatR;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.OnDisconnect
{
    public class OnDisconnectRequest : IRequest
    {
        public OnDisconnectRequest(
            string connectionId)
        {
            ConnectionId = connectionId;
        }

        public string ConnectionId { get; }
    }
}
