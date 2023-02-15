using Disco.Business.Interfaces.Dtos.Facebook;
using FluentValidation;

namespace Disco.Business.Interfaces.Validators
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
