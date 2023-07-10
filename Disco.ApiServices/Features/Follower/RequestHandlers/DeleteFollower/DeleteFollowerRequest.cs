using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.DeleteFollower
{
    public class DeleteFollowerRequest : IRequest 
    {
        public DeleteFollowerRequest(int id)
        {
            Id = id;
        }
        
        public int Id { get; }
    }
}
