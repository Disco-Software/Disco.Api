using MediatR;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.OnConnect
{
    public class OnConnectRequest : IRequest
    {
        public OnConnectRequest(
            string ticketName,
            string userName,
            string connectionId)
        {
            UserName = userName;
            TicketName = ticketName;
            ConnectionId = connectionId;

        }

        public string UserName { get; }
        public string TicketName { get; }
        public string ConnectionId { get; }
    }
}
