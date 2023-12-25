using Disco.Business.Interfaces.Dtos.Group.User.GetAllGroupMessages;
using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.Group.RequestHandlers.GetGroupMessages
{
    public class GetGroupMessagesRequest : IRequest<IEnumerable<GetAllGroupMessagesResponseDto>>
    {
        public GetGroupMessagesRequest(
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
