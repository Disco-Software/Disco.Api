using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.EmailNotifications
{
    public class EmailConfirmationModel
    {
        public string ToEmail { get; set; }
        public string Name { get; set; }
        public string MessageHeader { get; set; }
        public string MessageBody { get; set; }
        public bool IsHtmlTemplate { get; set; }
    }
}
