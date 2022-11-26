using Disco.Domain.Models;
using System;
using System.Security.Claims;

namespace Disco.Business.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        int GetTokenExpirce();
    }
}
