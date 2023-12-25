using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Account.User.Google
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
