using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account.User.LogIn;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Utils.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.LogIn
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

            var passwordResponse = await _accountPasswordService.VerifyPasswordAsync(user, request.Dto.Password);
            if (passwordResponse == PasswordVerificationResult.Failed)
            {
                throw new InvalidPasswordException(new Dictionary<string, string>
                {
                    {"password", "Password is not valid"}
                });
            }

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, refreshToken);

            var accountDto = _mapper.Map<AccountDto>(user.Account);
            var userDto = _mapper.Map<UserDto>(user);

            userDto.Account = accountDto;

            var responseDto = _mapper.Map<LogInResponseDto>(user);
            responseDto.AccessToken = accessToken;
            responseDto.RefreshToken = refreshToken;

            return responseDto;
        }
    }
}
