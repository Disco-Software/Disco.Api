using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class PostVideo : Base.BaseEntity<int>
    {
        public string VideoSource { get; set; }
    }
}
