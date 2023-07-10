using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Errors
{
    public class ErrorDto
    {
       public List<ErrorMessage> ErrorMessages { get; set; }   
    }
}
