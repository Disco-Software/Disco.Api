using Disco.Business.Interfaces.Dtos.AccountDetails;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetCurrentUser
{
    public class GetCurrentUserRequest : IRequest<UserDetailsResponseDto> { }
}
