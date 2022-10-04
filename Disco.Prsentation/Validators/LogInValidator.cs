using Disco.Business.Dtos.Authentication;
using Disco.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Disco.Presentation.Validators
{
    public class LogInValidator : AbstractValidator<LoginDto>
    {
        public LogInValidator(UserManager<User> userManager)
        {
            RuleFor(r => r.Email)
                .EmailAddress()
                .WithMessage("This is not email, please enter valid email")
                .MustAsync(async (email, cencelationToken) =>
                {
                    var user = await userManager.FindByEmailAsync(email);
                    return user != null;
                })
                .WithMessage("User not found")
                .NotEmpty()
                .WithMessage("Email can not be empty");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Password can not be empty");
        }

        public static LogInValidator Create(UserManager<User> userManager)
        {
            return new LogInValidator(userManager);
        }

    }
}
