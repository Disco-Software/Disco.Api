using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class NewPostNotification : BaseEntity.BaseEntity<int>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
    }
}
