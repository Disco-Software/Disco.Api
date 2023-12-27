using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountPhoto
{
    public class UserDto
    {
        public UserDto(
            int id,
            string roleName,
            string userName,
            string email)
        {
            Id = id;
            RoleName = roleName;
            UserName = userName;
            Email = email;
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string UserName {  get; set; }
        public string Email {  get; set; }
    }
}
