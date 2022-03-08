using Disco.BLL.Models;
using Disco.BLL.Models.Authentication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Validatars
{
    public class RegistrationValidator : AbstractValidator<RegistrationModel>
    {
        public static RegistrationValidator instance = new RegistrationValidator();
        private RegistrationValidator()
        {            
            RuleFor(f => f.UserName)
                .NotEmpty()
                .WithMessage("User name is requared");

            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email must be a valid email address");

            RuleFor(m => m.Password)
                .NotEmpty()
                .WithMessage("Password is required");         
        }
    }
}
