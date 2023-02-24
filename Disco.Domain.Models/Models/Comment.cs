using Disco.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Domain.Models.Models
{
    public class Comment : BaseModel<int>
    {
        public string CommentDescription { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
