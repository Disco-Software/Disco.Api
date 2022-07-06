using Disco.BLL.Configurations;
using Disco.BLL.Interfaces;
using Disco.DAL.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Disco.BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<AuthenticationOptions> authenticationOptions;

        public TokenService(IOptions<AuthenticationOptions> _options) =>
            authenticationOptions = _options;

        public string GenerateAccessToken(User user)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                authenticationOptions.Value.Issuer,
                authenticationOptions.Value.Audience,
                new[] { 
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.RoleName)
                },
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(authenticationOptions.Value.ExpiresAfterMitutes),
                new SigningCredentials(
                        new SymmetricSecurityKey(authenticationOptions.Value.SigningKeyBytes),
                        SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        public string GenerateRefreshToken()
        {
            var code = new byte[32];
            using (var randomNamberGenerator = RandomNumberGenerator.Create())
            {
                randomNamberGenerator.GetBytes(code);
                return Convert.ToBase64String(code);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
