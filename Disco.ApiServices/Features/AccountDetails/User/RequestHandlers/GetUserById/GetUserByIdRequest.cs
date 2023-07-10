using Disco.Business.Interfaces.Dtos.AccountDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetUserById
{
    public class GetUserByIdRequest : IRequest<UserDetailsResponseDto>
    {
        public GetUserByIdRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
