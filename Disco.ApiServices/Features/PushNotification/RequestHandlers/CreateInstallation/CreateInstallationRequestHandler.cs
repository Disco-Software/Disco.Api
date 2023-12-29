using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.PushNotification.RequestHandlers.CreateInstallation
{
    public class CreateInstallationRequestHandler : IRequestHandler<CreateInstallationRequest, string>
    {
        private readonly IPushNotificationService _notificationService;
        private readonly IHttpContextAccessor _contextAccessor;

        public CreateInstallationRequestHandler(
            IPushNotificationService notificationService, 
            IHttpContextAccessor contextAccessor)
        {
            _notificationService = notificationService;
            _contextAccessor = contextAccessor;
        }

        public async Task<string> Handle(CreateInstallationRequest request, CancellationToken cancellationToken)
        {
            var response = await _notificationService.CreateOrUpdateInstallationAsync(request.Dto, _contextAccessor.HttpContext.RequestAborted);

             return response;
        }
    }
}
