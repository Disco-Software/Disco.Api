using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Interfaces.Dtos.Statistics
{
    public class AuthenticationStatisticsDto
    {
        public List<User> RegisteredUsers { get; set; }
    }
}
