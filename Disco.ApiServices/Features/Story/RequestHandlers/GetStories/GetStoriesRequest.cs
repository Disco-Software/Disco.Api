using Disco.Business.Interfaces.Dtos.Stories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.GetStories
{
    public class GetStoriesRequest : IRequest<List<Domain.Models.Models.Story>>
    {
        public GetStoriesRequest(GetAllStoriesDto dto)
        {
            Dto = dto;
        }

        public GetAllStoriesDto Dto { get; }
    }
}
