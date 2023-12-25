using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Post.User.GetPosts
{
    public class UserDto
    {
        public UserDto(
            string userName, 
            string email)
        {
            UserName = userName;
            Email = email;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
