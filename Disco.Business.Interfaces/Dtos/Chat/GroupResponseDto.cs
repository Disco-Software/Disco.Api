using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Interfaces.Dtos.Chat
{
    public class GroupResponseDto
    {
        public string Name { get; set; }
        public List<Domain.Models.Models.Account> Accounts { get; set; }
        public List<Message> Messages { get; set; }
    }
}
