using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Services.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn
{
    public class LogInRequestHandler : IRequestHandler<LogInRequest, UserResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LogInRequestHandler(
            IAccountService accountService,
            IAccountPasswordService accountPasswordService,
            ITokenService tokenService,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> Handle(LogInRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Dto.Email);

            var passwordValidator = await _accountPasswordService.VerifyPasswordAsync(user, request.Dto.Password);
            if (passwordValidator == PasswordVerificationResult.Failed)
            {
                throw new Exception();
            }

            var roleResult = await _accountService.IsInRoleAsync(user, UserRole.Admin);
            if (roleResult == false)
            {
                throw new Exception();
            }

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, refreshToken);

            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            userResponseDto.AccessToken = accessToken;
            userResponseDto.RefreshToken = refreshToken;
            userResponseDto.User = user;

            return userResponseDto;
        }
    }
}
