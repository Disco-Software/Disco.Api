using Disco.Business.Interfaces;
using Disco.Business.Dtos.PushNotifications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Presentation.Controllers
{
    [Route("api/device-registration")]
    [ApiController]
    public class DeviceRegistrationController : ControllerBase
    {
        private readonly IRegisterDeviceService _registerDeviceService;

        public DeviceRegistrationController(IRegisterDeviceService registerDeviceService)
        {
            _registerDeviceService = registerDeviceService;
        }

        [HttpPost]
        public async Task<DeviceRegistrationDto> DeviceRegistration([FromBody] DeviceRegistrationDto model)
        {
            return await _registerDeviceService.RegisterDevice(model);
        }
    }
}
