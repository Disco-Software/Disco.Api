using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Dtos.AccountDetails
{
    public class UpdateAccountDto
    {
        public IFormFile Photo { get; set; }
    }
}
