using Microsoft.AspNetCore.Http;

namespace Disco.Business.Dtos.AccountDetails
{
    public class UpdateAccountDto
    {
        public IFormFile Photo { get; set; }
    }
}
