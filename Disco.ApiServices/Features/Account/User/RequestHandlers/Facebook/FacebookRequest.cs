using Disco.Business.Interfaces.Dtos.Account;
using Disco.Integration.Interfaces.Dtos.Facebook;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Account.User.RequestHandlers.Facebook
{
    public class FacebookRequest : IRequest<UserResponseDto>
    {
        public FacebookRequest(FacebookRequestDto dto)
        {
            Dto = dto;
        }

        public FacebookRequestDto Dto { get; }
    }
}
