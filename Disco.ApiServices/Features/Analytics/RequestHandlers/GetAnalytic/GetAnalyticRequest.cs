using Disco.Business.Interfaces.Dtos.Analytic.Admin.GetAnalytics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Analytics.RequestHandlers.GetAnalytic
{
    public class GetAnalyticRequest : IRequest<AnalyticResponseDto>
    {
        public GetAnalyticRequest(
            string from, 
            string to, 
            string analyticFor)
        {
            From = from;
            To = to;
            AnalyticFor = analyticFor;
        }

        public string From { get; }
        public string To { get; }
        public string AnalyticFor { get; }
    }
}
