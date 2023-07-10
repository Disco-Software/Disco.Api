using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.DeleteFollower
{
    internal class DeleteFollowerRequestHandler : IRequestHandler<DeleteFollowerRequest>
    {
        private readonly IFollowerService _followerService;

        public DeleteFollowerRequestHandler(IFollowerService followerService)
        {
            _followerService = followerService;
        }

        public async Task Handle(DeleteFollowerRequest request, CancellationToken cancellationToken)
        {
            await _followerService.DeleteAsync(request.Id);
        }
    }
}
