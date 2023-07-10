using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Interfaces.Dtos.Statistics
{
    public class AnalyticDto
    {
        public int UsersCount { get; set; }
        public int NewUsersCount { get; set; }
        public int PostsCount { get; set; }
        public List<User> Users { get; set; }
        public List<User> RegisteredUsers { get; set; }
        public List<Post> Posts { get; set; }
    }
}
