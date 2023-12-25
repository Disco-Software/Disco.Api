using Disco.Business.Interfaces.Dtos.Account.User.LogIn;
using MediatR;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.LogIn
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
