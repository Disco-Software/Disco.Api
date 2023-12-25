using MediatR;

namespace Disco.ApiServices.Features.Message.RequestHandlers.DeleteMessage
{
    public class DeleteMessageRequest : IRequest
    {
        public DeleteMessageRequest(
            int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
