using AutoMapper;
using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Dtos.Message.User.CreateMessage;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Message.RequestHandlers.CreateMessage
{
    public class CreateMessageRequestHandler : IRequestHandler<CreateMessageRequest, CreateMessageResponseDto>
    {
        private readonly IAccountService _accountService;
        private readonly IMessageService _messageService;
        private readonly IGroupService _groupService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CreateMessageRequestHandler(
            IAccountService accountService,
            IMessageService messageService,
            IGroupService groupService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _messageService = messageService;
            _groupService = groupService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;        
        }

        public async Task<CreateMessageResponseDto> Handle(CreateMessageRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var group = await _groupService.GetAsync(int.Parse(_contextAccessor.HttpContext.Request.Query["GroupId"]));

            var message = await _messageService.CreateAsync(request.CreateMessageRequestDto.Description, user.Account, group);

            var createMessageResponseDto = _mapper.Map<CreateMessageResponseDto>(message);

            return createMessageResponseDto;
        }
    }
}
