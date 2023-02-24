using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<List<User>>> GetUserStatistics([FromQuery] int days)
        {
           return await _adminStatisticsService.GetRegistredUsersDayAsync(days);
        }
    }
}
