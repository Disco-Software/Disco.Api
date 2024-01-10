using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Utils.Exceptions
{
    public class PasswordRecoveryException : Exception
    {
        public Dictionary<string, string> Errors { get; }

        public PasswordRecoveryException(Dictionary<string, string> errors)
        {
            Errors = errors;
        }
    }
}
