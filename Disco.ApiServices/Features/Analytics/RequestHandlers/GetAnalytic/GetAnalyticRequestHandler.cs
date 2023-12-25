using Disco.ApiServices.Features.Analytics.RequestHandlers.GetAnalytic;
using Disco.Business.Interfaces.Dtos.Analytic.Admin.GetAnalytics;
using Disco.Business.Interfaces.Enums;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Analytics.GetAnalytic
{
    public class GetAnalyticRequestHandler : IRequestHandler<GetAnalyticRequest, AnalyticResponseDto>
    {
        private readonly IAnalyticService _analyticService;

        public GetAnalyticRequestHandler(IAnalyticService analyticService)
        {
            _analyticService = analyticService;
        }

        public async Task<AnalyticResponseDto> Handle(GetAnalyticRequest request, CancellationToken cancellationToken)
        {
            var analyticFor = Enum.Parse<AnalyticFor>(request.AnalyticFor);

            var fromTime = DateTime.Parse(request.From);
            var toTime = DateTime.Parse(request.To);

            var analyticDto = await _analyticService.GetAnalyticAsync(fromTime, toTime, analyticFor);

            return analyticDto;

        }
    }
}
