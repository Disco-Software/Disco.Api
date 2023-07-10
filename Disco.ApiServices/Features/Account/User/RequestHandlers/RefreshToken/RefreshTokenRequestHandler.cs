using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.RefreshToken
{
    internal class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest, UserResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public RefreshTokenRequestHandler(IAccountService accountService, ITokenService tokenService, IMapper mapper)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByRefreshTokenAsync(request.Dto.RefreshToken);

            if (user.RefreshTokenExpiress >= DateTime.UtcNow.AddDays(7))
            {
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var userRefreshedResponseDto = _mapper.Map<UserResponseDto>(user);
                userRefreshedResponseDto.AccessToken = accessToken;
                userRefreshedResponseDto.RefreshToken = refreshToken;
                userRefreshedResponseDto.User = user;

                return userRefreshedResponseDto;
            }

            var accessResponseToken = _tokenService.GenerateAccessToken(user);

            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            userResponseDto.AccessToken = accessResponseToken;
            userResponseDto.RefreshToken = user.RefreshToken;
            userResponseDto.User = user;

            return userResponseDto;
        }
    }
}
