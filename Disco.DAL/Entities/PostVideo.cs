using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class PostVideo : Base.BaseEntity<int>
    {
        public string VideoSource { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
