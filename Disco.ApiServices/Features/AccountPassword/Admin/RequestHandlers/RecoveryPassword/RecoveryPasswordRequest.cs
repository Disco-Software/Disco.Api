using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ResetPassword;
using MediatR;

namespace Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.RecoveryPassword
{
    public class RecoveryPasswordRequest : IRequest<string>
    {
        public RecoveryPasswordRequest(RecoveryPasswordRequestDto dto)
        {
            Dto = dto;
        }

        public RecoveryPasswordRequestDto Dto { get; }
    }
}
