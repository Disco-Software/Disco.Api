﻿using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Account.Admin.LogIn;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Utils.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn
{
    public class LogInRequestHandler : IRequestHandler<LogInRequest, LogInResponseDto>
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

        public async Task<LogInResponseDto> Handle(LogInRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByEmailAsync(request.Dto.Email);

            var passwordValidator = await _accountPasswordService.VerifyPasswordAsync(user, request.Dto.Password);
            if (passwordValidator == PasswordVerificationResult.Failed)
            {
                throw new InvalidPasswordException(new Dictionary<string, string>
                {
                    {"password", "Password is invalid"}
                });
            }

            var roleResult = await _accountService.IsInRoleAsync(user, UserRole.ADMIN_ROLE);
            if (roleResult == false)
            {
                throw new InvalidRoleException(new Dictionary<string, string>
                {
                    {"role", "You don't have a rules to login to admin panel"}
                });
            }

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, refreshToken);

            var accountDto = _mapper.Map<AccountDto>(user.Account);
            var userDto = _mapper.Map<UserDto>(user);

            var logInResponseDto = _mapper.Map<LogInResponseDto>(userDto);
            logInResponseDto.AccessToken = accessToken;
            logInResponseDto.RefreshToken = refreshToken;

            return logInResponseDto;
        }
    }
}
