using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Google
{
    public class GoogleRequestHandler : IRequestHandler<GoogleRequest, UserResponseDto>
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

        public async Task<UserResponseDto> Handle(GoogleRequest request, CancellationToken cancellationToken)
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

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken = refreshToken;
                userResponseDto.User = user;

                return userResponseDto;
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

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken = refreshToken;
                userResponseDto.User = user;

                return userResponseDto;
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

            var userRegisterResponseDto = _mapper.Map<UserResponseDto>(user);
            userRegisterResponseDto.RefreshToken = userRefreshToken;
            userRegisterResponseDto.User = user;
            userRegisterResponseDto.AccessToken = userAccessToken;

            return userRegisterResponseDto;
        }
    }
}
