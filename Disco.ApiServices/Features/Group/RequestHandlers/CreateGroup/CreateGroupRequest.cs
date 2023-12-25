using Disco.Business.Interfaces.Dtos.Group.User.CreateGroup;
using MediatR;

namespace Disco.ApiServices.Features.Group.RequestHandlers.CreateGroup
{
    public class CreateGroupRequest : IRequest<CreateGroupResponseDto>
    {
        public CreateGroupRequest(CreateGroupRequestDto dto)
        {
            Dto = dto;
        }

        public CreateGroupRequestDto Dto { get; }
    }
}
