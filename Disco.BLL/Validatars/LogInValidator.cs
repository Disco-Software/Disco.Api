using Disco.Business.Dto.Authentication;
using Disco.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Validatars
{
    public class LogInValidator : AbstractValidator<LoginDto>
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
