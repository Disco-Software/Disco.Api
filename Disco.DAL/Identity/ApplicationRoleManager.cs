using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Identity
{
    public class ApplicationRoleManager : Microsoft.AspNetCore.Identity.RoleManager<Role>
    {
        public ApplicationRoleManager(IRoleStore<Role> role, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer lookupNormalizer, IdentityErrorDescriber identityErrorDescriber, ILogger<RoleManager<Role>> logger) : base(role,roleValidators, lookupNormalizer, identityErrorDescriber, logger)
        {

        }
    }
}
