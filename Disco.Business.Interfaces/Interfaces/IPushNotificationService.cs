using Disco.Business.Interfaces.Dtos.PushNotifications;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IPushNotificationService
    {
        Task<string> CreateOrUpdateInstallationAsync(DeviceInstallationDto dto, CancellationToken cancellationToken = default);
        Task<bool> DeleteInstallationByIdAsync(string installationId, CancellationToken token = default);
        Task<bool> RequestNotificationAsync(PushNotificationBaseDto dto, CancellationToken token = default);
    }
}
