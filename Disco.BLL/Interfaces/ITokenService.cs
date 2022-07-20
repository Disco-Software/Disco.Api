using Disco.Domain.Models;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
