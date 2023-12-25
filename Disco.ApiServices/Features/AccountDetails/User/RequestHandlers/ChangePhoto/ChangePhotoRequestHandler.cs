using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.User.ChangePhoto;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.ChangePhoto
{
    public class ChangePhotoRequestHandler : IRequestHandler<ChangePhotoRequest, ChangePhotoResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public ChangePhotoRequestHandler(
            IAccountService accountService, 
            IAccountDetailsService accountDetailsService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<ChangePhotoResponseDto> Handle(ChangePhotoRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var account = await _accountDetailsService.ChengePhotoAsync(user, request.Dto.Photo);

            var accountDto = _mapper.Map<AccountDto>(user.Account);
            var userDto = _mapper.Map<UserDto>(user);

            var changePhotoResponseDto = _mapper.Map<ChangePhotoResponseDto>(userDto);

            return changePhotoResponseDto;
        }
    }
}
