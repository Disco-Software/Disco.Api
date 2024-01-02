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
        private readonly Dictionary<string, string> _errors;

        public PasswordRecoveryException(Dictionary<string, string> errors)
        {
            _errors = errors;
        }
    }
}
