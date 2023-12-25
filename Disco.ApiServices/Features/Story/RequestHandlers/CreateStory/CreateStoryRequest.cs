using Disco.Business.Interfaces.Dtos.Stories;
using Disco.Business.Interfaces.Dtos.Stories.User.CreateStory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.CreateStory
{
    public class CreateStoryRequest : IRequest<CreateStoryResponseDto>
    {
        public CreateStoryRequest(CreateStoryRequestDto dto)
        {
            Dto = dto;
        }

        public CreateStoryRequestDto Dto { get; }
    }
}
