using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ChangeSelectedUserPassword;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ChangeSelectedUserPassword
{
    public class ChangeSelectedUserPasswordRequest : IRequest<ChangeSelectedUserPasswordResponseDto>
    {
        public ChangeSelectedUserPasswordRequest(
            ChangeSelectedUserPasswordRequestDto changeSelectedUserPasswordRequestDto)
        {
            ChangeSelectedUserPasswordRequestDto = changeSelectedUserPasswordRequestDto;
        }

        public ChangeSelectedUserPasswordRequestDto ChangeSelectedUserPasswordRequestDto { get; }
    }
}
