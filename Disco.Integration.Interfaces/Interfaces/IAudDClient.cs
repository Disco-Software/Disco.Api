using Disco.Integration.Interfaces.Dtos.AudD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Integration.Interfaces.Interfaces
{
    public interface IAudDClient
    {
        Task<AudDDto> CheckAuthorAsync(AudDRequestDto dto);
    }
}
