using Disco.Business.Interfaces.Dtos.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn
{
    public class LogInRequest : IRequest<UserResponseDto>
    {
        public LogInRequest(LoginDto dto)
        {
            Dto = dto;
        }

        public LoginDto Dto { get; }
    }
}
