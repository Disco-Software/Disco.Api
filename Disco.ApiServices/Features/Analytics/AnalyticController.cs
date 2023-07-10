using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Analytics.GetAnalytic;
using Disco.ApiServices.Features.Analytics.RequestHandlers.GetAnalytic;
using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Statistics;
using Disco.Business.Interfaces.Enums;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Analytics
{
    [Route("api/admin/analitycs")]
    public class AnalyticController : AdminController
    {
        private readonly IMediator _mediator;

        public AnalyticController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<AnalyticDto>> GetAnalitycAsync(
            [FromQuery] string from,
            [FromQuery] string to,
            [FromQuery] string analyticFor) =>
            await _mediator.Send(new GetAnalyticRequest(from, to, analyticFor));
    }
}
