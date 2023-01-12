using Disco.Business.Dtos.Friends;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Validators
{
    public class CreateFollowerValidator : AbstractValidator<CreateFollowerDto>
    {
        private CreateFollowerValidator(IAccountService accountService, ClaimsPrincipal claimsPrincipal)
        {
            RuleFor(r => r.FollowerAccountId)
                .MustAsync(async (id, token) =>
                {
                    var account = await accountService.GetAsync(claimsPrincipal);
                    return account.Id == id;
                })
                .WithMessage("You can't subscribe to your self");
        }

        public static CreateFollowerValidator Create(IAccountService accountService, ClaimsPrincipal claimsPrincipal)
        {
            return new CreateFollowerValidator(accountService, claimsPrincipal);
        }
    }
}
