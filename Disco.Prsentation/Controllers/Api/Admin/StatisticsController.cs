using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Presentation.Controllers.Admin
{
    [Route("api/admin/statistics")]
    [ApiController]
    [Authorize(
        AuthenticationSchemes = AuthScheme.UserToken,
        Roles = UserRole.Admin)]
    public class StatisticsController : ControllerBase
    {
        private readonly IAdminStatisticsService _adminStatisticsService;

        public StatisticsController(IAdminStatisticsService adminStatisticsService)
        {
            _adminStatisticsService = adminStatisticsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUserStatistics([FromQuery] int days)
        {
           return await _adminStatisticsService.GetRegistredUsersDayAsync(days);
        }
    }
}
