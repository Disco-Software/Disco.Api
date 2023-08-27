using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.GetStory
{
    public class GetStoryRequestHandler : IRequestHandler<GetStoryRequest, Domain.Models.Models.Story>
    {
        private readonly IStoryService _storyService;

        public GetStoryRequestHandler(IStoryService storyService)
        {
            _storyService = storyService;
        }

        public async Task<Domain.Models.Models.Story> Handle(GetStoryRequest request, CancellationToken cancellationToken)
        {
            var story = await _storyService.GetStoryAsync(request.Id);

            return story;
        }
    }
}
