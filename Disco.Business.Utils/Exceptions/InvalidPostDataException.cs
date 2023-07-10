using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Utils.Exceptions
{
    public class InvalidPostDataException : Exception
    {
        public Dictionary<string, string> Errors { get; }

        public InvalidPostDataException(Dictionary<string, string> errors)
        {
            Errors = errors;
        }
    }
}
