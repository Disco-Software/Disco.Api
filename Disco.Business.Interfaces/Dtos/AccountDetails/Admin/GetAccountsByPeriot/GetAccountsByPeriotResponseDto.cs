using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAccountsByPeriot
{
    public class GetAccountsByPeriotResponseDto
    {
        public GetAccountsByPeriotResponseDto(UserDto user)
        {
            User = user;
        }

        public UserDto User { get; set; }
    }
}
