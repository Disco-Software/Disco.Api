using MediatR;

namespace Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.RecoveryPasswordCodeChecking
{
    public class RecoveryPasswordCodeCheckingRequest : IRequest<bool>
    {
        public RecoveryPasswordCodeCheckingRequest(
            string email,
            int code)
        {
            Email = email;
            Code = code;
        }

        public string Email {  get; }

        public int Code { get; }
    }
}
