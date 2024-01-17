using Disco.Business.Constants;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        private readonly IPushNotificationService _pushNotificationService;
        private readonly INotificationService _notificationService;
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _contextAccessor;

        public SendNewsNotificationRequestHandler(
            IPushNotificationService pushNotificationService,
            INotificationService notificationService,
            IAccountService accountService,
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _notificationService = notificationService;
            _pushNotificationService = pushNotificationService;
            _contextAccessor = contextAccessor;
        }

        public async Task Handle(SendNewsNotificationRequest request, CancellationToken cancellationToken)
        {
            var list = new List<User>();
            
            var sender = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var dataPayload = NotificationTemplates.DataNotification.ADMIN_NOTIFICATION
                .Replace("(name)", sender.UserName)
                .Replace("(type)", NotificationTypes.APP_NOTIFICATION)
                .Replace("(photo)", sender.Account.Photo)
                .Replace("(message)", request.Dto.Body)
                .Replace("(date)", DateTime.UtcNow.ToString());

            foreach (var userName in request.Dto.UserNames)
            {
                var user = await _accountService.GetByNameAsync(userName);

                var notification = new Domain.Models.Models.Notification(
                    request.Dto.Title,
                    request.Dto.Body,
                    dataPayload,
                    user.AccountId,
                    user.Account);

                await _notificationService.CreateAsync(notification);

                list.Add(user);
            }

            await _pushNotificationService.RequestNotificationAsync(
                new Business.Interfaces.Dtos.NewsNotification.Admin.NewsNotificationEvent.NewsNotificationEventDto(request.Dto.Title, request.Dto.Body, dataPayload), list);
        }
    }
}
