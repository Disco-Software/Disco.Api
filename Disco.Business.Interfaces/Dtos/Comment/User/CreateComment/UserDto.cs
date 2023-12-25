using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Comment.User.CreateComment
{
    public class UserDto
    {
        public UserDto(
            string userName,
            string email)
        {
            Email = email;
            UserName = userName;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
