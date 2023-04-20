using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Enums;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers.Admin
{
    [Route("api/admin/statistics")]
    [ApiController]
    [Authorize(
        AuthenticationSchemes = AuthSchema.UserToken,
        Roles = UserRole.Admin)]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _adminStatisticsService;

        public StatisticsController(IStatisticsService adminStatisticsService)
        {
            _adminStatisticsService = adminStatisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatisticsAsync(
            [FromQuery] string from,
            [FromQuery] string to,
            [FromQuery] string statistics)
        {
            var statisticsFor = Enum.Parse<StatisticsFor>(statistics);
            
            var fromTime = DateTime.Parse(from);
            var toTime = DateTime.Parse(to);


            switch (statisticsFor)
            {
                case StatisticsFor.Day:
                    {
                        var statisticsDto = await _adminStatisticsService.GetAllStatisticsAsync(fromTime, toTime, statisticsFor);

                        return Ok(statisticsDto);
                    }
                case StatisticsFor.Week:
                    {
                        var statisticsDto = await _adminStatisticsService.GetAllStatisticsAsync(fromTime, toTime, statisticsFor);

                        return Ok(statisticsDto);
                    }
                case StatisticsFor.Month:
                    {
                        var statisticsDto = await _adminStatisticsService.GetAllStatisticsAsync(fromTime, toTime, statisticsFor);

                        return Ok(statisticsDto);
                    }
                case StatisticsFor.Year:
                    {
                        var statisticsDto = await _adminStatisticsService.GetAllStatisticsAsync(fromTime, toTime, statisticsFor);

                        return Ok(statisticsDto);
                    }
                default: return BadRequest();
            }
        }
    }
}
