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

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Apple
{
    public class AppleRequestHandler : IRequestHandler<AppleRequest, UserResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AppleRequestHandler(IAccountService accountService, ITokenService tokenService, IMapper mapper)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> Handle(AppleRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Dto.Email);
            if (user != null)
            {
                user.Email = request.Dto.Email;
                user.UserName = request.Dto.Name;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken = refreshToken;
                userResponseDto.User = user;

                return userResponseDto;
            }

            user = await _accountService.GetByLogInProviderAsync(LogInProvider.Apple, request.Dto.AppleIdCode);
            if (user != null)
            {
                user.Email = request.Dto.Email;
                user.UserName = request.Dto.Name;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken = refreshToken;
                userResponseDto.User = user;

                return userResponseDto;
            }

            user = new Domain.Models.Models.User
            {
                UserName = request.Dto.Name,
                DateOfRegister = DateTime.UtcNow,
                Email = request.Dto.Email,
                Account = new Domain.Models.Models.Account
                {
                    User = user,
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                }
            };

            await _accountService.CreateAsync(user);

            var userAccessToken = _tokenService.GenerateAccessToken(user);
            var userRefreshToken = _tokenService.GenerateRefreshToken();

            var userRegisterResponseDto = _mapper.Map<UserResponseDto>(user);
            userRegisterResponseDto.RefreshToken = userRefreshToken;
            userRegisterResponseDto.User = user;
            userRegisterResponseDto.AccessToken = userAccessToken;

            return userRegisterResponseDto;
        }
    }
}
