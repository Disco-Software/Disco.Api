using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Group.RequestHandlers.DeleteGroup
{
    public class DeleteGroupRequest : IRequest
    {
        public DeleteGroupRequest(int groupId)
        {
            GroupId = groupId;
        }
        
        public int GroupId { get; }
    }
}
