using Disco.Business.Interfaces;
using Disco.Business.Dto;
using Disco.Business.Dto.PushNotifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [Route("api/device-registration")]
    [ApiController]
    public class DeviceRegistrationController : ControllerBase
    {
        private readonly IRegisterDeviceService registerDeviceService;

        public DeviceRegistrationController(IRegisterDeviceService registerDeviceService)
        {
            this.registerDeviceService = registerDeviceService;
        }

        [HttpPost]
        public async Task<DeviceRegistrationDto> DeviceRegistration([FromBody] DeviceRegistrationDto model)
        {
            return await registerDeviceService.RegisterDevice(model);
        }
    }
}
