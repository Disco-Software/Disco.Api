using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public Dictionary<string, string> Errors { get; }

        public ResourceNotFoundException(Dictionary<string, string> errors)
        {
            Errors = errors;
        }
    }
}
