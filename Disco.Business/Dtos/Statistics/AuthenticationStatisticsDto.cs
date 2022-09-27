using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dtos.Statistics
{
    public class AuthenticationStatisticsDto
    {
        public List<User> RegisteredUsers { get; set; }
    }
}
