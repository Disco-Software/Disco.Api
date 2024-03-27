using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Disco.ApiServices.Features.TicketMessage.RequestHandlers.DeleteMessageForAll
{
    public class DeleteMessageForAllRequest : IRequest
    {
        public DeleteMessageForAllRequest(
            int id,
            ClaimsPrincipal claimsPrincipal)
        {
            Id = id;
            ClaimsPrincipal = claimsPrincipal;
        }

        public int Id { get; }
        public ClaimsPrincipal ClaimsPrincipal { get; }
    }
}
