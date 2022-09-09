using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.PushNotifications;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class RegisterDeviceService : IRegisterDeviceService
    {
        private readonly NotificationHubClient _notificationHubClient;
        private readonly IConfiguration _configuration;
        public RegisterDeviceService(IConfiguration configuration)
        {
            _configuration = configuration;
            _notificationHubClient = NotificationHubClient.CreateClientFromConnectionString(Strings.NotificationConnectionString, Strings.NotificationName);        }

        public async Task<Installation> GetInstallation(DeviceRegistrationDto model)
        {
            try
            {
               return await _notificationHubClient.GetInstallationAsync(model.InstallationId);
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
                await _notificationHubClient.CreateOrUpdateInstallationAsync(instatalation);

                return model;
            }
           
            var instalationId = Guid.NewGuid().ToString();

            await _notificationHubClient.CreateOrUpdateInstallationAsync(new Installation
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
