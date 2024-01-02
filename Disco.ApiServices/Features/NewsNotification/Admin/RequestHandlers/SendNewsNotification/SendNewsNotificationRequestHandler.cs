using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.NewsNotification.Admin.RequestHandlers.SendNewsNotification
{
    public class SendNewsNotificationRequestHandler : IRequestHandler<SendNewsNotificationRequest>
    {
        private readonly IPushNotificationService _notificationService;
        private readonly IAccountService _accountService;

        public SendNewsNotificationRequestHandler(
            IPushNotificationService notificationService,
            IAccountService accountService)
        {
            _accountService = accountService;
            _notificationService = notificationService;
        }

        public async Task Handle(SendNewsNotificationRequest request, CancellationToken cancellationToken)
        {
            var list = new List<User>();
            foreach (var userName in request.Dto.UserNames)
            {
                var user = await _accountService.GetByNameAsync(userName);

                list.Add(user);
            }

            await _notificationService.RequestNotificationAsync(new Business.Interfaces.Dtos.PushNotifications.PushNotificationBaseDto
            {
                Title = request.Dto.Title,
                Body = request.Dto.Body,
            }, list);
        }
    }
}
