using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.DeleteStory
{
    public class DeleteStoryRequest : IRequest<string>
    {
        public DeleteStoryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
