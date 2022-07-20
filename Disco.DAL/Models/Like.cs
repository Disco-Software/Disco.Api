using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Models
{
    public class Like : Base.BaseEntity<int>
    {
        public string UserName { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
