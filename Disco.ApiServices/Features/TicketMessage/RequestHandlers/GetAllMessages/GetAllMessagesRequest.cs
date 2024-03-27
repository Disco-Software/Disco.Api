using Disco.Business.Interfaces.Dtos.TicketMessage.GetAllMessages;
using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.GetAllMessages
{
    public class GetAllMessagesRequest : IRequest<IEnumerable<GetAllMessagesResponseDto>>
    {
        public GetAllMessagesRequest(
            int groupId,
            int pageNumber,
            int pageSize)
        {
            GroupId = groupId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int GroupId { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
    }
}
