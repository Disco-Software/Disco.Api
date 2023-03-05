using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Disco.Business.Interfaces.Interfaces;
using Disco.Integration.Interfaces.Interfaces;
using Disco.Integration.Interfaces.Dtos.AudD;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Route("api/user/copywrite")]
    [Authorize(AuthenticationSchemes = AuthSchema.UserToken)]
    public class AudDController : ControllerBase
    {
        private readonly IAudDClient _audDClient;

        public AudDController(IAudDClient audDClient)
        {
            _audDClient = audDClient;
        }

        [HttpPost("recognize")]
        public async Task<IActionResult> RecognizeAsync([FromForm] AudDRequestDto dto)
        {
            var result = await _audDClient.CheckAuthorAsync(dto);
            
            if(result == null)
            {
                return Ok("This song do not have a copywrite");
            }

            return BadRequest(result);
        }
    }
}
