using Disco.BLL.Dto;
using Disco.BLL.Dto.EmailNotifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IEmailService
    {
         void EmailConfirmation(EmailConfirmationDto model);
    }
}
