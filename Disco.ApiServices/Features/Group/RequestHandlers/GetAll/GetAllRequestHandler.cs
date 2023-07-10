using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Group.RequestHandlers.GetAll
{
    internal class GetAllRequestHandler : IRequestHandler<GetAllRequest, IEnumerable<Domain.Models.Models.Group>>
    {
        private readonly IAccountService _accountService;
        private readonly IGroupService _groupService;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllRequestHandler(IAccountService accountService, IGroupService groupService, IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _groupService = groupService;
            _contextAccessor = contextAccessor;
        }

        public async Task<IEnumerable<Domain.Models.Models.Group>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var groups = await _groupService.GetAllAsync(user.Id, request.PageNumber, request.PageSize);

            return groups;
        }
    }
}
