using AutoMapper;
using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.LogIn
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

            var passwordResponse = await _accountPasswordService.VerifyPasswordAsync(user, request.Dto.Password);
            if (passwordResponse == PasswordVerificationResult.Failed)
            {
                throw new ResourceNotFoundException(new Dictionary<string, string>
                {
                    {"password", "Password is not valid"}
                });
            }

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, refreshToken);

            var responseDto = _mapper.Map<UserResponseDto>(user);
            responseDto.AccessToken = accessToken;

            return responseDto;
        }
    }
}
