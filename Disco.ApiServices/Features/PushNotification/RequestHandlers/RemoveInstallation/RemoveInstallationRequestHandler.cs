using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.PushNotification.RequestHandlers.RemoveInstallation
{
    public class RemoveInstallationRequestHandler : IRequestHandler<RemoveInstallationRequest, string>
    {
        private readonly IPushNotificationService _notificationService;

        public RemoveInstallationRequestHandler(IPushNotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<string> Handle(RemoveInstallationRequest request, CancellationToken cancellationToken)
        {
            var response = await _notificationService.DeleteInstallationByIdAsync(request.InstallationId);

            if (!response)
            {
                return $"Installation remove status: {response}";
            }

            return $"Installation remove status: {response}";
        }
    }
}
