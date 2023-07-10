using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.ChangePhoto
{
    internal class ChangePhotoRequestHandler : IRequestHandler<ChangePhotoRequest, Domain.Models.Models.User>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IHttpContextAccessor _contextAccessor;

        public ChangePhotoRequestHandler(
            IAccountService accountService, 
            IAccountDetailsService accountDetailsService,
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _contextAccessor = contextAccessor;
        }

        public async Task<Domain.Models.Models.User> Handle(ChangePhotoRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var account = await _accountDetailsService.ChengePhotoAsync(user, request.Dto.Photo);

            return user;
        }
    }
}
