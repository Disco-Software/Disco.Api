using AutoMapper;
using Azure.Core;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Account.User.Facebook;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Integration.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Facebook
{
    public class FacebookRequestHandler : IRequestHandler<FacebookRequest, FacebookResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IFacebookClient _facebookClient;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public FacebookRequestHandler(
            IAccountService accountService, 
            IFacebookClient facebookClient,
            ITokenService tokenService,
            IMapper mapper)
        {
            _accountService = accountService;
            _facebookClient = facebookClient;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<FacebookResponseDto> Handle(FacebookRequest request, CancellationToken cancellationToken)
        {
            var userInfo = await _facebookClient.GetInfoAsync(request.Dto.FacebookAccessToken);
            userInfo.Name = userInfo.Name.Replace(" ", "_");

            var user = await _accountService.GetByLogInProviderAsync(LogInProvider.Facebook, userInfo.Id);
            if (user != null)
            {
                user.Email = userInfo.Email;
                user.UserName = userInfo.Name;
                user.Account.Photo = userInfo.Picture.Data.Url;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var accountDto = _mapper.Map<AccountDto>(user.Account);
                var userDto = _mapper.Map<UserDto>(user);

                var facebookLogInResponseDto = _mapper.Map<FacebookResponseDto>(userDto);
                facebookLogInResponseDto.AccessToken = accessToken;
                facebookLogInResponseDto.RefreshToken = refreshToken;

                return facebookLogInResponseDto;
            }

            user = await _accountService.GetByEmailAsync(userInfo.Email);
            if (user != null)
            {
                user.Email = userInfo.Email;
                user.UserName = userInfo.Name;
                user.Account.Photo = userInfo.Picture.Data.Url;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var accountDto = _mapper.Map<AccountDto>(user.Account);
                var userDto = _mapper.Map<UserDto>(user);

                var facebookLogInResponseDto = _mapper.Map<FacebookResponseDto>(userDto);
                facebookLogInResponseDto.AccessToken = accessToken;
                facebookLogInResponseDto.RefreshToken = refreshToken;

                return facebookLogInResponseDto;
            }

            user = new Domain.Models.Models.User
            {
                UserName = userInfo.Name,
                DateOfRegister = DateTime.UtcNow,
                Email = userInfo.Email,
                Account = new Domain.Models.Models.Account
                {
                    User = user,
                    Photo = userInfo.Picture.Data.Url,
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>()
                }
            };

            await _accountService.CreateAsync(user);

            var userAccessToken = _tokenService.GenerateAccessToken(user);
            var userRefreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, userRefreshToken);

            var accountRegisterDto = _mapper.Map<AccountDto>(user.Account);
            var userRegisterDto = _mapper.Map<UserDto>(user);

            var facebookRegisterResponseDto = _mapper.Map<FacebookResponseDto>(userRegisterDto);
            facebookRegisterResponseDto.AccessToken = userAccessToken;
            facebookRegisterResponseDto.RefreshToken = userRefreshToken;

            return facebookRegisterResponseDto;
        }
    }
}
