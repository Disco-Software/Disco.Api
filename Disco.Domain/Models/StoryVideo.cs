using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disco.Domain.Models
{
    public class StoryVideo : Base.BaseModel<int>
    {
        public string Source { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfCreation { get; set; }

        public int StoryId { get; set; }
        public Story Story { get; set; }
    }
}
