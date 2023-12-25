using Disco.Business.Interfaces.Dtos.Analytic.Admin.GetAnalytics;
using Disco.Business.Interfaces.Enums;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IAnalyticService
    {
        Task<AnalyticResponseDto> GetAnalyticAsync(DateTime from, DateTime to, AnalyticFor statistics);
    }
}
