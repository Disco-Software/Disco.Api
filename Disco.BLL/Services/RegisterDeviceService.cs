using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.PushNotifications;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class RegisterDeviceService : IRegisterDeviceService
    {
        private readonly NotificationHubClient notificationHubClient;
        public RegisterDeviceService(NotificationHubClient _notificationHubClient) =>
            notificationHubClient = _notificationHubClient;

        public async Task<Installation> GetInstallation(DeviceRegistrationModel model)
        {
            try
            {
               return await notificationHubClient.GetInstallationAsync(model.InstallationId);
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, $"exception {ex}");
                return new Installation
                {
                    InstallationId = model.InstallationId,
                    Platform = model.Platform.Value
                };
            }
        }

        public async Task<DeviceRegistrationModel> RegisterDevice(DeviceRegistrationModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.InstallationId))
            {
                var instatalation = await GetInstallation(model);
                
                instatalation.PushChannel = model.PlatformDeviceId;
                instatalation.PushChannelExpired = false;
                await notificationHubClient.CreateOrUpdateInstallationAsync(instatalation);

                return model;
            }
           
            var instalationId = Guid.NewGuid().ToString();

            await notificationHubClient.CreateOrUpdateInstallationAsync(new Installation
            {
                InstallationId = instalationId,
                PushChannel = model.PlatformDeviceId,
                Platform = model.Platform.Value
            });

            return new DeviceRegistrationModel
            {
                InstallationId = instalationId,
                Platform = model.Platform.Value,
                PlatformDeviceId = model.PlatformDeviceId
            };

        }
    }
}
