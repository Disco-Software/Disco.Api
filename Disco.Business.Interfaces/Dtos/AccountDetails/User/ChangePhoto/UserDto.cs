using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.AccountDetails.User.ChangePhoto
{
    public class UserDto
    {
        public UserDto(
            string roleName, 
            string userName,
            string email,
            AccountDto account)
        {
            RoleName = roleName;
            Email = email;
            UserName = userName;
            Account = account;
        }

        public string RoleName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public AccountDto Account { get; set; }
    }
}
