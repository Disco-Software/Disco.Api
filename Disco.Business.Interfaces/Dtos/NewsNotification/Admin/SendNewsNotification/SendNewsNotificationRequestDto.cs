using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.NewsNotification.Admin.SendNewsNotification
{
    public class SendNewsNotificationRequestDto
    {
        public SendNewsNotificationRequestDto(
            IEnumerable<string> userNames, 
            string title, 
            string body)
        {
            UserNames = userNames;
            Title = title;
            Body = body;
        }

        public IEnumerable<string> UserNames { get; set; }
        public string Title {  get; set; }
        public string Body {  get; set; }
    }
}
