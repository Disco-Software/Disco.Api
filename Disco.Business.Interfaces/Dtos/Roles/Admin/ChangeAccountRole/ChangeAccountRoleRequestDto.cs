using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Roles.Admin.ChangeAccountRole
{
    public class ChangeAccountRoleRequestDto
    {
        public ChangeAccountRoleRequestDto(
            int id,
            string roleName)
        {
            Id = id;
            RoleName = roleName;
        }

        public int Id { get; set; }
        public string RoleName {  get; set; }
    }
}
