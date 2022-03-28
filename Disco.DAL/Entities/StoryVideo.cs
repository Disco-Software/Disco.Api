using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class StoryVideo : Base.BaseEntity<int>
    {
        public string Source { get; set; }

        public int StoryId { get; set; }
        public Story Story { get; set; }
    }
}
