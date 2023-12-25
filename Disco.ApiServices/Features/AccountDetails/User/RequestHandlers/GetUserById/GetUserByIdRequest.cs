using Disco.Business.Interfaces.Dtos.AccountDetails.User.GetUserById;
using MediatR;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetUserById
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponseDto>
    {
        public GetUserByIdRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
