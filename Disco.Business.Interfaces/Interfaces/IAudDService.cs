using Disco.Business.Interfaces.Dtos.AudD;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IAudDService
    {
        Task<AudDDto> RecognizeAsync(AudDRequestDto dto);
    }
}
