using Disco.Business.Dto.Facebook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Validatars
{
    public class FacebookAccessTokenValidator : AbstractValidator<FacebookRequestDto>
    {
        public FacebookAccessTokenValidator()
        {
            RuleFor(rule => rule.AccessToken)
                .NotEmpty()
                .WithMessage("Access token can not be empty");
        }

        public static FacebookAccessTokenValidator Create()
        {
            return new FacebookAccessTokenValidator();
        }

    }
}
