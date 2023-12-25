using MediatR;

namespace Disco.ApiServices.Features.Message.RequestHandlers.OnConnect
{
    public class OnConnectRequest : IRequest
    {
        public OnConnectRequest(string connectionId)
        {
            ConnectionId = connectionId;
        }

        public string ConnectionId { get; }
    }
}
