using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Interfaces.Dtos.Analytic
{
    public class AnalyticDto
    {
        public int UsersCount { get; set; }
        public int NewUsersCount { get; set; }
        public int PostsCount { get; set; }

        public List<int> AggregatedPosts { get; set; } = new List<int>();
        public List<int> AggregatedUsers { get; set; } = new List<int>();
        public List<int> AggregatedNewUsers { get; set; } = new List<int>(); 
    }
}
