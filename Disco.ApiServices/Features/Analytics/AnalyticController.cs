using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Analytics.RequestHandlers.GetAnalytic;
using Disco.Business.Interfaces.Dtos.Analytic.Admin.GetAnalytics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<AnalyticResponseDto>> GetAnalitycAsync(
            [FromQuery] string from,
            [FromQuery] string to,
            [FromQuery] string analyticFor) =>
            await _mediator.Send(new GetAnalyticRequest(from, to, analyticFor));
    }
}
