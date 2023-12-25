using AutoMapper;
using Azure.Core;
using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken
{
    public class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest, RefreshTokenResponseDto>
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

        public async Task<RefreshTokenResponseDto> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByRefreshTokenAsync(request.Dto.RefreshToken);

            if (user == null)
                throw new ResourceNotFoundException(new Dictionary<string, string> { { "email", "Email is not valid" } });

            if (user.RefreshTokenExpiress >= DateTime.UtcNow.AddDays(7))
            {
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var accountDto = _mapper.Map<AccountDto>(user.Account);
                var userDto = _mapper.Map<UserDto>(user);

                userDto.Account = accountDto;

                var refreshTokenResponseDto = _mapper.Map<RefreshTokenResponseDto>(userDto);
                refreshTokenResponseDto.AccessToken = accessToken;
                refreshTokenResponseDto.RefreshToken = refreshToken;

                return refreshTokenResponseDto;
            }

            var accessResponseToken = _tokenService.GenerateAccessToken(user);

            var accountRefreshDto = _mapper.Map<AccountDto>(user.Account);
            var userRefreshDto = _mapper.Map<UserDto>(user);

            userRefreshDto.Account = accountRefreshDto;

            var refreshTokenDto = _mapper.Map<RefreshTokenResponseDto>(userRefreshDto);
            refreshTokenDto.AccessToken = accessResponseToken;
            refreshTokenDto.RefreshToken = user.RefreshToken;

            return refreshTokenDto;
        }
    }
}
