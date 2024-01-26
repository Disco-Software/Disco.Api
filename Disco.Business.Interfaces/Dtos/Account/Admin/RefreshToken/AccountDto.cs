using Disco.Business.Utils.Guards;

namespace Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken
{
    public class AccountDto
    {
        public AccountDto(
            string photo,
            string cread)
        {
            Photo = photo;
            Cread = cread;
        }

        public string Photo { get; set; }
        public string Cread { get; set; }
    }
}
