using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Models
{
    public class Profile : Base.BaseEntity<int>
    {
        public string Status { get; set; }
        public string Cread { get; set; } = string.Empty;
        public string Photo { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Friend> Followers { get; set; } = new List<Friend>();
        public List<Friend> Following { get; set; } = new List<Friend>();
        public List<Story> Stories { get; set; } = new List<Story>();

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
