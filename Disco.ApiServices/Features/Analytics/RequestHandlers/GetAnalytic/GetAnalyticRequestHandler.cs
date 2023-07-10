using Disco.ApiServices.Features.Analytics.RequestHandlers.GetAnalytic;
using Disco.Business.Interfaces.Dtos.Statistics;
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
    internal class GetAnalyticRequestHandler : IRequestHandler<GetAnalyticRequest, AnalyticDto>
    {
        private readonly IAnalyticService _analyticService;

        public GetAnalyticRequestHandler(IAnalyticService analyticService)
        {
            _analyticService = analyticService;
        }

        public async Task<AnalyticDto> Handle(GetAnalyticRequest request, CancellationToken cancellationToken)
        {
            var analyticFor = Enum.Parse<AnalyticFor>(request.AnalyticFor);

            var fromTime = DateTime.Parse(request.From);
            var toTime = DateTime.Parse(request.To);


            switch (analyticFor)
            {
                case AnalyticFor.Day:
                    {
                        var analyticDto = await _analyticService.GetAllStatisticsAsync(fromTime, toTime, analyticFor);

                        return analyticDto;
                    }
                case AnalyticFor.Week:
                    {
                        var analyticDto = await _analyticService.GetAllStatisticsAsync(fromTime, toTime, analyticFor);

                        return analyticDto;
                    }
                case AnalyticFor.Month:
                    {
                        var analyticDto = await _analyticService.GetAllStatisticsAsync(fromTime, toTime, analyticFor);

                        return analyticDto;
                    }
                case AnalyticFor.Year:
                    {
                        var analyticDto = await _analyticService.GetAllStatisticsAsync(fromTime, toTime, analyticFor);

                        return analyticDto;
                    }
                default: throw new Exception();
            }
        }
    }
}
