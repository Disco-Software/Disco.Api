using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAccountsByPeriot;
using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsByPeriot
{
    public class GetAccountsByPeriotRequest : IRequest<List<GetAccountsByPeriotResponseDto>>
    {
        public GetAccountsByPeriotRequest(int periot)
        {
            Periot = periot;
        }

        public int Periot { get; }
    }
}
