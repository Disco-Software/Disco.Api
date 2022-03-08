using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.PushNotifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Controllers.PushNotifications
{
    [Route("api/device-registration")]
    [ApiController]
    public class DeviceRegistrationController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public DeviceRegistrationController(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;

        [HttpPost]
        public async Task<DeviceRegistrationModel> DeviceRegistration([FromBody] DeviceRegistrationModel model) =>
            await serviceManager.RegisterDeviceService.RegisterDevice(model);
    }
}
