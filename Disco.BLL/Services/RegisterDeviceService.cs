using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dto;
using Disco.Business.Dto.PushNotifications;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class RegisterDeviceService : IRegisterDeviceService
    {
        private readonly NotificationHubClient notificationHubClient;
        private readonly IConfiguration configuration;
        public RegisterDeviceService(IConfiguration _configuration)
        {
            configuration = _configuration;
            notificationHubClient = NotificationHubClient.CreateClientFromConnectionString(
                configuration[Strings.NOTIFICATION_CONNECTION_STRING],
                configuration[Strings.NOTIFICATION_NAME]);
        }

        public async Task<Installation> GetInstallation(DeviceRegistrationDto model)
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

        public async Task<DeviceRegistrationDto> RegisterDevice(DeviceRegistrationDto model)
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

            return new DeviceRegistrationDto
            {
                InstallationId = instalationId,
                Platform = model.Platform.Value,
                PlatformDeviceId = model.PlatformDeviceId
            };

        }
    }
}
