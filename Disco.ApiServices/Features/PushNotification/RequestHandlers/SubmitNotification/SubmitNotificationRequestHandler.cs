using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.PushNotification.RequestHandlers.SubmitNotification
{
    public class SubmitNotificationRequestHandler : IRequestHandler<SubmitNotificationRequest, string>
    {
        private readonly IPushNotificationService _notificationService;
        private readonly IHttpContextAccessor _contextAccessor;

        public SubmitNotificationRequestHandler(
            IPushNotificationService notificationService, 
            IHttpContextAccessor contextAccessor)
        {
            _notificationService = notificationService;
            _contextAccessor = contextAccessor;
        }

        public async Task<string> Handle(SubmitNotificationRequest request, CancellationToken cancellationToken)
        {
            var response = await _notificationService.RequestNotificationAsync(request.Dto, _contextAccessor.HttpContext.RequestAborted);

            if (!response)
            {
                return $"Submit status: {response}";
            }

            return $"Submit status: {response}";
        }
    }
}
