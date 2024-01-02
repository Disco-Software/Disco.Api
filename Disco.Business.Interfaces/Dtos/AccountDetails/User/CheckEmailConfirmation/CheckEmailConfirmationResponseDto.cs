using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.AccountDetails.User.CheckEmailConfirmation
{
    public class CheckEmailConfirmationResponseDto
    {
        public CheckEmailConfirmationResponseDto(
            bool isSucceeded)
        {
            IsSucceeded = isSucceeded;
        }

        public bool IsSucceeded { get; set; }
    }
}
