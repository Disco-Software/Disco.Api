using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Disco.Business.Interfaces.Validators.Account
{
    public class LogInValidator : AbstractValidator<LoginDto>
    {
        public LogInValidator(IAccountService accountService)
        {
            RuleFor(r => r.Email)
                .EmailAddress()
                .WithMessage("This is not email, please enter valid email")
                .MustAsync(async (email, cencelationToken) =>
                {
                    var user = await accountService.GetByEmailAsync(email);
                    return user != null;
                })
                .WithMessage("User not found")
                .NotEmpty()
                .WithMessage("Email can not be empty");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Password can not be empty");
        }
    }
}
