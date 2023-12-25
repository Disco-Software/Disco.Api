using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Dtos.Account.User.Register;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Registration
{
    public class RegistrationRequestHandler : IRequestHandler<RegistrationRequest, RegisterResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public RegistrationRequestHandler(IAccountService accountService, IAccountPasswordService accountPasswordService, ITokenService tokenService, IMapper mapper)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<RegisterResponseDto> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Models.Models.User>(request.Dto);

            user.Email = request.Dto.Email;
            user.UserName = request.Dto.UserName;
            user.Account = new Domain.Models.Models.Account();
            user.Account.User = user;
            user.Account.Id = user.Id;
            user.Account.Followers = new List<UserFollower>();
            user.Account.Following = new List<UserFollower>();
            user.Account.Posts = new List<Domain.Models.Models.Post>();
            user.Account.Stories = new List<Domain.Models.Models.Story>();

            await _accountService.CreateAsync(user);

            _accountPasswordService.AddPasswod(user, request.Dto.Password);

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, refreshToken);

            var accountDto = _mapper.Map<AccountDto>(user.Account);
            var userDto = _mapper.Map<UserDto>(user);

            var userResponseDto = _mapper.Map<RegisterResponseDto>(userDto);
            userResponseDto.RefreshToken = refreshToken;
            userResponseDto.AccessToken = accessToken;

            return userResponseDto;
        }
    }
}
