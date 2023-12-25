using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Account.User.Facebook;
using Disco.Business.Interfaces.Dtos.Account.User.Google;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AccountDto = Disco.Business.Interfaces.Dtos.Account.User.Google.AccountDto;
using UserDto = Disco.Business.Interfaces.Dtos.Account.User.Google.UserDto;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Google
{
    public class GoogleRequestHandler : IRequestHandler<GoogleRequest, GoogleResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public GoogleRequestHandler(
            IAccountService accountService,
            ITokenService tokenService, 
            IMapper mapper)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<GoogleResponseDto> Handle(GoogleRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Dto.Email);
            if (user != null)
            {
                user.Email = request.Dto.Email;
                user.UserName = request.Dto.UserName;
                user.Account.Photo = request.Dto.Photo;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var accountDto = _mapper.Map<AccountDto>(user.Account);
                var userDto = _mapper.Map<UserDto>(user);

                userDto.Account = accountDto;

                var googleLogInResponseDto = _mapper.Map<GoogleResponseDto>(userDto);
                googleLogInResponseDto.AccessToken = accessToken;
                googleLogInResponseDto.RefreshToken = refreshToken;

                return googleLogInResponseDto;
            }

            user = await _accountService.GetByLogInProviderAsync(LogInProvider.Google, request.Dto.IdToken);
            if (user != null)
            {
                user.Account.Photo = request.Dto.Photo;
                user.UserName = request.Dto.UserName;
                user.Email = request.Dto.Email;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var accountDto = _mapper.Map<AccountDto>(user.Account);
                var userDto = _mapper.Map<UserDto>(user);

                userDto.Account = accountDto;

                var googleLogInResponseDto = _mapper.Map<GoogleResponseDto>(userDto);

                return googleLogInResponseDto;
            }

            user = new Domain.Models.Models.User
            {
                UserName = request.Dto.UserName,
                DateOfRegister = DateTime.UtcNow,
                Email = request.Dto.Email,
                Account = new Domain.Models.Models.Account
                {
                    Photo = request.Dto.Photo,
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                }
            };

            await _accountService.CreateAsync(user);

            var userAccessToken = _tokenService.GenerateAccessToken(user);
            var userRefreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, userRefreshToken);

            var registeredAccountDto = _mapper.Map<AccountDto>(user.Account);
            var registeredUserDto = _mapper.Map<UserDto>(user);

            registeredUserDto.Account = registeredAccountDto;

            var userRegisterResponseDto = _mapper.Map<GoogleResponseDto>(user);
            userRegisterResponseDto.RefreshToken = userRefreshToken;
            userRegisterResponseDto.AccessToken = userAccessToken;

            return userRegisterResponseDto;
        }
    }
}
