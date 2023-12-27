using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAccount;
using MediatR;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccount
{
    public class GetAccountRequest : IRequest<GetAccountResponseDto>
    {
        public GetAccountRequest(
            int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
