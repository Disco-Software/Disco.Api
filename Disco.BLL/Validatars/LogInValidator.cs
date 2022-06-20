using Disco.BLL.Models.Authentication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Validatars
{
    public class LogInValidator : AbstractValidator<LoginModel>
    {
        public LogInValidator() 
        {
            RuleFor(r => r.Email)
                .EmailAddress()
                .WithMessage("This is not email, please enter valid email")
                .NotEmpty()
                .WithMessage("Email can not be empty");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Password can not be empty");
        }

        public static LogInValidator Create()
        {
            return new LogInValidator();
        }

    }
}
