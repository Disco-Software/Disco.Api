using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountEmail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.ChangeAccountEmail
{
    public class ChangeAccountEmailRequest : IRequest<ChangeAccountEmailResponseDto>
    {
        public ChangeAccountEmailRequest(ChangeAccountEmailRequestDto changeAccountEmailRequestDto)
        {
            ChangeAccountEmailRequestDto = changeAccountEmailRequestDto;
        }

        public ChangeAccountEmailRequestDto ChangeAccountEmailRequestDto { get; }
    }
}
