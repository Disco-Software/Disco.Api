using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.CreateAccount
{
    public class CreateAccountRequestHandler : IRequestHandler<CreateAccountRequest, UserResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public CreateAccountRequestHandler(IAccountService accountService, ITokenService tokenService, IMapper mapper)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Models.Models.User>(request.Dto);
            user.Email = request.Dto.Email;
            user.UserName = request.Dto.UserName;
            user.Account = new Domain.Models.Models.Account
            {
                User = user,
                UserId = user.Id,
            };

            await _accountService.CreateAsync(user);

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, refreshToken);

            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            userResponseDto.RefreshToken = refreshToken;
            userResponseDto.AccessToken = accessToken;
            userResponseDto.User = user;

            return userResponseDto;
        }
    }
}
