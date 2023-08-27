using Disco.Business.Interfaces.Dtos.Stories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.CreateStory
{
    public class CreateStoryRequest : IRequest<Domain.Models.Models.Story>
    {
        public CreateStoryRequest(CreateStoryDto dto)
        {
            Dto = dto;
        }

        public CreateStoryDto Dto { get; }
    }
}
