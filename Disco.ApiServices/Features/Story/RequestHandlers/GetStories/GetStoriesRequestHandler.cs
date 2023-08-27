using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.GetStories
{
    public class GetStoriesRequestHandler : IRequestHandler<GetStoriesRequest, List<Domain.Models.Models.Story>>
    {
        private readonly IAccountService _accountService;
        private readonly IStoryService _storyService;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetStoriesRequestHandler(
            IAccountService accountService, 
            IStoryService storyService, 
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _storyService = storyService;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<Domain.Models.Models.Story>> Handle(GetStoriesRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var stories = await _storyService.GetAllStoryAsync(user, request.Dto);

            return stories;
        }
    }
}
