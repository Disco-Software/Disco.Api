using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Google.Apis.Logging;
using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class RegisterDeviceService : IDeviceRegistration
    {
        //    private readonly INotificationHubClient client;
        //    private readonly ILogger logger;
        //    public RegisterDeviceService(INotificationHubClient _client, ILogger _logger)
        //    {
        //        client = _client;
        //        logger = _logger;
        //    }

        //    public async Task<Installation> RegisterDevice(DeviceRegistrationModel registerDTO)
        //    {
        //        if (!string.IsNullOrWhiteSpace(registerDTO.InstallationId))
        //        {
        //            var installation = await GetInstallation(registerDTO);

        //            installation.PushChannel = registerDTO.PlatformDeviceId;
        //            installation.PushChannelExpired = false;
        //            await client.CreateOrUpdateInstallationAsync(installation);
        //            return installation;
        //        }

        //        var installationInfo = new Installation
        //        {
        //            InstallationId = registerDTO.InstallationId,
        //            Platform = registerDTO.Platform.Value,
        //            PushChannel = registerDTO.PlatformDeviceId
        //        };
        //        var installationId = Guid.NewGuid().ToString();
        //        await client.CreateOrUpdateInstallationAsync(installationInfo);
        //        return installationInfo;
        //    }
        //    public async Task<Installation> GetInstallation(DeviceRegistrationModel model) 
        //    {
        //        try
        //        {
        //            return await client.GetInstallationAsync(model.InstallationId);
        //        }
        //        catch (Exception ex)
        //        {
        //            logger.Error(ex, "Original Installation failed.  Recreating as new.");
        //        }
        //    }
        //}
    }
}
