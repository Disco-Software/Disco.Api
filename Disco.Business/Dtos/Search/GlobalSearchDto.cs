using System;
using System.Collections.Generic;
using System.Text;
using Disco.Domain.Models;
namespace Disco.Business.Dtos.Search
{
    public class GlobalSearchResponseDto
    {
        public IEnumerable<Domain.Models.Account> Profile { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
