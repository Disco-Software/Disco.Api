using Disco.Integrations.Interfaces.Dtos.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Integrations.Interfaces.Interfaces
{
    public interface IFacebookClient
    {
        Task<TokenValidationResponseDto> ValidateAsync(string accessToken);
        Task<FacebookDto> GetInfoAsync(string accessToken);
    }
}
