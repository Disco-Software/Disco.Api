using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Executor : BaseEntity.BaseEntity<int>
    {
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}
