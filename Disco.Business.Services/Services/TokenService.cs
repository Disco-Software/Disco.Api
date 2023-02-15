using Disco.Business.Interfaces.Options;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<AuthenticationOptions> _authenticationOptions;

        public TokenService(IOptions<AuthenticationOptions> options) =>
            _authenticationOptions = options;

        public string GenerateAccessToken(User user)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                _authenticationOptions.Value.Issuer,
                _authenticationOptions.Value.Audience,
                new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.RoleName)
                },
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(_authenticationOptions.Value.ExpiresAfterMitutes),
                new SigningCredentials(
                        new SymmetricSecurityKey(_authenticationOptions.Value.SigningKeyBytes),
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
    }
}
