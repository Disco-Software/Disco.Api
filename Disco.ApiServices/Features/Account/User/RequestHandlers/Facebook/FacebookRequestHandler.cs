using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Integration.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Facebook
{
    public class FacebookRequestHandler : IRequestHandler<FacebookRequest, UserResponseDto>
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

        public async Task<UserResponseDto> Handle(FacebookRequest request, CancellationToken cancellationToken)
        {
            var userInfo = await _facebookClient.GetInfoAsync(request.Dto.AccessToken);
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

                var userRsponseDto = _mapper.Map<UserResponseDto>(user);
                userRsponseDto.AccessToken = accessToken;
                userRsponseDto.RefreshToken = refreshToken;
                userRsponseDto.User = user;

                return userRsponseDto;
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

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken = refreshToken;
                userResponseDto.User = user;

                return userResponseDto;
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

            var userRegisterResponseDto = _mapper.Map<UserResponseDto>(user);
            userRegisterResponseDto.RefreshToken = userRefreshToken;
            userRegisterResponseDto.User = user;
            userRegisterResponseDto.AccessToken = userAccessToken;

            return userRegisterResponseDto;
        }
    }
}
