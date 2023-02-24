using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Security.Claims;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}
