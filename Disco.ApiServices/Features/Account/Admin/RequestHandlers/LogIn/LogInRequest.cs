using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Dtos.Account.Admin.LogIn;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn
{
    public class LogInRequest : IRequest<LogInResponseDto>
    {
        public LogInRequest(LogInRequestDto dto)
        {
            Dto = dto;
        }

        public LogInRequestDto Dto { get; }
    }
}
