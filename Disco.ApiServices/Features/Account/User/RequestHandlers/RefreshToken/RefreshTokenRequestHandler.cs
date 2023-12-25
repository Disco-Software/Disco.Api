using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account.User.RefreshToken;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.RefreshToken
{
    internal class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest, RefreshTokenResponseDto>
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

            if (user.RefreshTokenExpiress >= DateTime.UtcNow.AddDays(7))
            {
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var accountRefreshedDto = _mapper.Map<AccountDto>(user.Account); 
                var userRefreshedDto = _mapper.Map<UserDto>(user);

                userRefreshedDto.Account = accountRefreshedDto;

                var userRefreshedResponseDto = _mapper.Map<RefreshTokenResponseDto>(user);
                userRefreshedResponseDto.AccessToken = accessToken;
                userRefreshedResponseDto.RefreshToken = refreshToken;

                return userRefreshedResponseDto;
            }

            var accessResponseToken = _tokenService.GenerateAccessToken(user);

            var accountDto = _mapper.Map<AccountDto>(user.Account);
            var userDto = _mapper.Map<UserDto>(user);

            userDto.Account = accountDto;

            var userResponseDto = _mapper.Map<RefreshTokenResponseDto>(userDto);
            userResponseDto.AccessToken = accessResponseToken;
            userResponseDto.RefreshToken = user.RefreshToken;

            return userResponseDto;
        }
    }
}
