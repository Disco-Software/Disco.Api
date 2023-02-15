using System;
using System.Collections.Generic;
using System.Text;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Dtos.Search
{
    public class GlobalSearchResponseDto
    {
        public IEnumerable<Domain.Models.Models.Account> Accounts { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
