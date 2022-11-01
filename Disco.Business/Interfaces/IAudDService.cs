using Disco.Business.Dtos.AudD;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAudDService
    {
        Task<AudDDto> RecognizeAsync(AudDRequestDto dto);
    }
}
