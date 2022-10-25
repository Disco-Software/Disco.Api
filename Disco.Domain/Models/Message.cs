using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Domain.Models
{
    public class Message : Base.BaseModel<int>
    {
        public int UserProfileId { get; set; }
        public Profile UserProfile { get; set; }

        public string MessageText { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
