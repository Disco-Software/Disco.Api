using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.EmailNotifications.User.ResetPassword
{
    public class ResetPasswordRequestDto
    {
        public ResetPasswordRequestDto(
            string toEmail, 
            string messageHeader, 
            string messageBody, 
            int code, 
            bool isHtmlTemplate)
        {
            ToEmail = toEmail;
            MessageHeader = messageHeader;
            MessageBody = messageBody;
            Code = code;
            IsHtmlTemplate = isHtmlTemplate;
        }

        public string ToEmail {  get; set; }
        public string MessageHeader { get; set; }
        public string MessageBody { get; set; }
        public int Code { get; set; }
        public bool IsHtmlTemplate {  get; set; }
    }
}
