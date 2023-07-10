using Disco.Business.Interfaces.Dtos.Chat;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Group.RequestHandlers.CreateGroup
{
    public class CreateGroupRequest : IRequest<Domain.Models.Models.Group>
    {
        public CreateGroupRequest(CreateGroupRequestDto dto)
        {
            Dto = dto;
        }

        public CreateGroupRequestDto Dto { get; }
    }
}
