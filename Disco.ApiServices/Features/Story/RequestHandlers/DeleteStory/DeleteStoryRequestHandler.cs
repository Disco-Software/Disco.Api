using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.DeleteStory
{
    public class DeleteStoryRequestHandler : IRequestHandler<DeleteStoryRequest, string>
    {
        private readonly IStoryService _storyService;

        public DeleteStoryRequestHandler(IStoryService storyService)
        {
            _storyService = storyService;
        }

        public async Task<string> Handle(DeleteStoryRequest request, CancellationToken cancellationToken)
        {
            await _storyService.DeleteStoryAsync(request.Id);

            return "Story was removed";
        }
    }
}
