using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Infrastructure
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class UserRolesAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        public const string Admin = "Admin";
        public const string User = "User"; 
        // This is a positional argument
        public UserRolesAttribute()
        {

            // TODO: Implement code here

            throw new NotImplementedException();
        }

        public string Fan
        {
            get { return User; }
        }

        // This is a named argument
        public int NamedInt { get; set; }
    }
}
