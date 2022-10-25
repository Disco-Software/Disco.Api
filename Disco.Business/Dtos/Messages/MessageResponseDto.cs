using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dtos.Messages
{
    public class MessageResponseDto
    {
        public Domain.Models.Profile UserProfile { get; set; }

        public string MessageText { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
