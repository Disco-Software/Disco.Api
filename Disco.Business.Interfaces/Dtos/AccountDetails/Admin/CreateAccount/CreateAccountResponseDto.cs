using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.CreateAccount
{
    public class CreateAccountResponseDto
    {
        public CreateAccountResponseDto(UserDto user)
        {
            User = user;
        }

        public UserDto User { get; set; }
    }
}
