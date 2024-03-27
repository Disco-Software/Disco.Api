using MediatR;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.OnConnect
{
    public class OnConnectRequest : IRequest
    {
        public OnConnectRequest(
            string ticketName,
            string userName,
            string connectionId,
            string userAgent)
        {
            UserName = userName;
            TicketName = ticketName;
            ConnectionId = connectionId;
            UserAgent = userAgent;
        }

        public string UserName { get; }
        public string TicketName { get; }
        public string ConnectionId { get; }
        public string UserAgent { get; }
    }
}
