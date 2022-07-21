using Disco.Business.Interfaces;
using Disco.Business.Dtos.PushNotifications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
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
