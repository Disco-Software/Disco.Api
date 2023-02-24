using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Attributes
{
    public class ValidationTypeAttribute : Attribute
    {
        private Type ValidationType { get; set; }

        public ValidationTypeAttribute(Type validationType)
        {
            ValidationType = validationType;
        }
    }
}
