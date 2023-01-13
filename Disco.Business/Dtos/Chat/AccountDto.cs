using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Dtos.Chat
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public UserDto User { get; set; }
    }
}
