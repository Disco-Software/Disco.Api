using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.CreateAccount;
using MediatR;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.CreateAccount
{
    public class CreateAccountRequest : IRequest<CreateAccountResponseDto>
    {
        public CreateAccountRequest(CreateAccountRequestDto dto)
        {
            Dto = dto;
        }
        
        public CreateAccountRequestDto Dto { get; }
    }
}
