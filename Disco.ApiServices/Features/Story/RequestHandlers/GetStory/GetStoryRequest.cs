using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.GetStory
{
    public class GetStoryRequest : IRequest<Domain.Models.Models.Story>
    {
        public GetStoryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
