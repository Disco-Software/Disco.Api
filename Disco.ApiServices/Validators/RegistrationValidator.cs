﻿using Disco.Business.Dtos.Authentication;
using Disco.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Disco.ApiServices.Validators
{
    public class RegistrationValidator : AbstractValidator<RegistrationDto>
    {
        private RegistrationValidator(
            UserManager<User> userManager)
        {
            RuleFor(f => f.UserName)
                .MustAsync(async (name, token) =>
                {
                    var user = await userManager.FindByNameAsync(name);
                    return user == null;
                })
                .WithMessage("this user already created");

            RuleFor(m => m.Email)
                .MustAsync(async (email, token) =>
                {
                    var user = await userManager.FindByEmailAsync(email);
                    return user == null;
                })
                .WithMessage("This email already registered");
        }

        public static RegistrationValidator Create(UserManager<User> userManager)
        {
            return new RegistrationValidator(userManager);
        }
    }
}