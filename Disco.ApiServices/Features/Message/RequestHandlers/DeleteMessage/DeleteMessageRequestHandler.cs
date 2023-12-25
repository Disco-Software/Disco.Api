using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Message.RequestHandlers.DeleteMessage
{
    public class DeleteMessageRequestHandler : IRequestHandler<DeleteMessageRequest>
    {
        private readonly IMessageService _messageService;

        public DeleteMessageRequestHandler(
            IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task Handle(DeleteMessageRequest request, CancellationToken cancellationToken)
        {
            var message = await _messageService.GetByIdAsync(request.Id);

            await _messageService.DeleteAsync(message);
        }
    }
}
