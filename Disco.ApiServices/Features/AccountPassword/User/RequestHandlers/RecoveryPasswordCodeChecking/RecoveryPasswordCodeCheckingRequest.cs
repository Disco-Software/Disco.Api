using MediatR;

namespace Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.RecoveryPasswordCodeChecking
{
    public class RecoveryPasswordCodeCheckingRequest : IRequest<bool>
    {
        public RecoveryPasswordCodeCheckingRequest(
            string email,
            int code)
        {
            Code = code;
        }

        public string Email { get; }

        public int Code { get; }
    }
}
