using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Utils.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public Dictionary<string, string> Errors { get; }

        public InvalidPasswordException(Dictionary<string, string> errors)
        {
            Errors = errors;
        }
    }
}
