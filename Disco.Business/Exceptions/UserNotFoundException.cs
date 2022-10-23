using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() { }
        public UserNotFoundException(string message) : base(message) { }
    }
}
