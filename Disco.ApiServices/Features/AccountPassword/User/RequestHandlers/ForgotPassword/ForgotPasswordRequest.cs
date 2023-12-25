using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ForgotPassword;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.ForgotPassword
{
    public class ForgotPasswordRequest : IRequest<string>
    {
        public ForgotPasswordRequest(ForgotPasswordDto dto)
        {
            Dto = dto;
        }

        public ForgotPasswordDto Dto { get; }
    }
}
