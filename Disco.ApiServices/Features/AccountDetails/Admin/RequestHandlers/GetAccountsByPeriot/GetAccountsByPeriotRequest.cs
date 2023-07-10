using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsByPeriot
{
    public class GetAccountsByPeriotRequest : IRequest<List<Domain.Models.Models.User>>
    {
        public GetAccountsByPeriotRequest(int periot)
        {
            Periot = periot;
        }

        public int Periot { get; }
    }
}
