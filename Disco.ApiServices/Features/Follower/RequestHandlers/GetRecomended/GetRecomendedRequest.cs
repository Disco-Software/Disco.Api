using Disco.Business.Interfaces.Dtos.Followers.User.GetRecomended;
using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetRecomended
{
    public class GetRecomendedRequest : IRequest<IEnumerable<GetRecomendedResponseDto>>
    {
        public GetRecomendedRequest(
            int userId, 
            int pageNumber, 
            int pageSize)
        {
            UserId = userId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int UserId { get;set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
