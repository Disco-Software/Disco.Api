using Disco.BLL.Dto.Facebook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Validatars
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
