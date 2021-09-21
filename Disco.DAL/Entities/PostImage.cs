using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class PostImage : Base.BaseEntity<int>
    {
        public string Source { get; set; }
    }
}
