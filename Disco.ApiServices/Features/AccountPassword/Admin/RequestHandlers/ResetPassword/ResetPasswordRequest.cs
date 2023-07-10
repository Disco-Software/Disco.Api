using Disco.Business.Interfaces.Dtos.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ResetPassword
{
    public class ResetPasswordRequest : IRequest<string>
    {
        public ResetPasswordRequest(ResetPasswordDto dto)
        {
            Dto = dto;
        }

        public ResetPasswordDto Dto { get; }
    }
}
