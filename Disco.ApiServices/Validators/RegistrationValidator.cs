using Disco.Business.Dtos.Account;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Disco.ApiServices.Validators
{
    public class RegistrationValidator : AbstractValidator<RegistrationDto>
    {
        private RegistrationValidator(
            IAccountService accountService)
        {
            RuleFor(f => f.UserName)
                .MustAsync(async (name, token) =>
                {
                    var user = await accountService.GetByNameAsync(name);
                    return user != null;
                })
                .WithMessage("this user already created");

            RuleFor(m => m.Email)
                .MustAsync(async (email, token) =>
                {
                    var user = await accountService.GetByEmailAsync(email);
                    return user != null;
                })
                .WithMessage("This email already registered");
        }

        public static RegistrationValidator Create(IAccountService accountService)
        {
            return new RegistrationValidator(accountService);
        }
    }
}
