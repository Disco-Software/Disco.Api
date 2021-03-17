using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendToEmailAsync(string to, string subject, string body);
        void SendToEmail(string to, string subject, string body);
    }
}
