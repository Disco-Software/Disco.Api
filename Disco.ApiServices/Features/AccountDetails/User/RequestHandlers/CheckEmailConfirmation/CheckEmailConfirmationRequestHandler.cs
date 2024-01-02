using Disco.Business.Interfaces.Dtos.AccountDetails.User.CheckEmailConfirmation;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Utils.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.CheckEmailConfirmation
{
    public class CheckEmailConfirmationRequestHandler : IRequestHandler<CheckEmailConfirmationRequest, CheckEmailConfirmationResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IHttpContextAccessor _contextAccessor;

        public CheckEmailConfirmationRequestHandler(
            IAccountService accountService,
            IAccountDetailsService accountDetailsService,
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _contextAccessor = contextAccessor;
        }

        public async Task<CheckEmailConfirmationResponseDto> Handle(CheckEmailConfirmationRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Email);

            var codeExpiredDate = _contextAccessor.HttpContext.Session.GetString("codeExpired");
            
            var date = DateTime.Parse(codeExpiredDate);

            if(DateTime.UtcNow >=  date)
            {
                _contextAccessor.HttpContext.Session.Remove("codeExpired");
                _contextAccessor.HttpContext.Session.Remove("codeExpired");

                throw new FailedEmailConfirmationException(new Dictionary<string, string>
                {
                    {"Code", "Code was Expired"}
                });
            }

            await _accountDetailsService.ConfirmEmailAsync(user);

            return new CheckEmailConfirmationResponseDto(true);
        }
    }
}
