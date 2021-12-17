using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Profile : Base.BaseEntity<int>
    {
        public string Status { get; set; }
        public string Photo { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
