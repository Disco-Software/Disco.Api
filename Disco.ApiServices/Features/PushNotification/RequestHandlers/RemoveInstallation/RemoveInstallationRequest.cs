using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.PushNotification.RequestHandlers.RemoveInstallation
{
    public class RemoveInstallationRequest : IRequest<string>
    {
        public RemoveInstallationRequest(string installationId)
        {
            InstallationId = installationId;
        }

        public string InstallationId { get; }
    }
}
