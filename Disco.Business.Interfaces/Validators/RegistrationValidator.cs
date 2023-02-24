using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Interfaces;
using FluentValidation;

namespace Disco.Business.Interfaces.Validators
{
    public class RegistrationValidator : AbstractValidator<RegistrationDto>
    {
        private RegistrationValidator(
            IAccountService accountService)
        {
            RuleFor(f => f.UserName)
                .NotNull()
                .WithMessage("this variable can't be null");

            RuleFor(m => m.Email)
                .NotNull()
                .WithMessage("This variable can't be null");
        }
    }
}
