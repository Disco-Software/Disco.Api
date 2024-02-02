using MediatR;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.DeleteMesssageForSender
{
    public class DeleteForSenderRequest : IRequest
    {
        public DeleteForSenderRequest(int ticketMessageId)
        {
            TicketMessageId = ticketMessageId;
        }

        public int TicketMessageId {  get; }
    }
}
