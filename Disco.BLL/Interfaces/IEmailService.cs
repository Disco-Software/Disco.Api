using Disco.Business.Dto;
using Disco.Business.Dto.EmailNotifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IEmailService
    {
         void EmailConfirmation(EmailConfirmationDto model);
    }
}
