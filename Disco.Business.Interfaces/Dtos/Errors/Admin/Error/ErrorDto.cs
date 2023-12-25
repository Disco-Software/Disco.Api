using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Errors.Admin.Error
{
    public class ErrorDto
    {
        public ErrorDto(
            List<ErrorMessage> errorMessages)
        {
            ErrorMessages = errorMessages;
        }

        public List<ErrorMessage> ErrorMessages { get; set; }
    }
}
