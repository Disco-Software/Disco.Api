using Disco.Business.Interfaces.Dtos.AccountDetails.User.CheckEmailConfirmation;
using MediatR;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.CheckEmailConfirmation
{
    public class CheckEmailConfirmationRequest : IRequest<CheckEmailConfirmationResponseDto>
    {
        public CheckEmailConfirmationRequest(
            string email,
            int code)
        {
            Email = email;
            Code = code;
        }

        public string Email { get; }
        public int Code { get; }
    }
}
