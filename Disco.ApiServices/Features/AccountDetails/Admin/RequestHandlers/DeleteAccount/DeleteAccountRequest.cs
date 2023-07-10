using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.DeleteAccount
{
    public class DeleteAccountRequest : IRequest
    {
        public DeleteAccountRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
