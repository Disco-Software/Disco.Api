using Disco.BLL.Models;
using Disco.BLL.Models.Authentication;
using Disco.DAL.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Validatars
{
    public class RegistrationValidator : AbstractValidator<RegistrationModel>
    {
        private RegistrationValidator(
            UserManager<User> userManager)
        {
            RuleFor(f => f.UserName)
                .MustAsync(async (name, token) =>
                {
                    var user = await userManager.FindByNameAsync(name);
                    return user != null;
                })
                .WithMessage("this user already created");

            RuleFor(m => m.Email)
                .MustAsync(async (email, token) =>
                {
                    var user = await userManager.FindByEmailAsync(email);
                    return user != null;
                })
                .WithMessage("This email already registered");
        }

        public static RegistrationValidator Create(UserManager<User> userManager) =>
            new RegistrationValidator(userManager);
    }
}
