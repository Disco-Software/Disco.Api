using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dtos.Chat
{
    public class GroupResponseDto
    {
        public string Name { get; set; }
        public List<Domain.Models.Account> Accounts { get; set; }
        public List<Message> Messages { get; set; }
    }
}
