using AutoMapper;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Resolvers
{
    public class AccountToTicketUserConvertor : ITypeConverter<Domain.Models.Models.Account, TicketUser>
    {
        public TicketUser Convert(Account source, TicketUser destination, ResolutionContext context)
        {
            var ticketUser = new TicketUser
            {
                UserName = source.User.UserName!,
                RoleName = source.User.RoleName!,
                Photo = source.Photo ?? "",
            };

            return ticketUser;
        }
    }
}
