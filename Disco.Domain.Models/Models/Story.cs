using System.ComponentModel.DataAnnotations.Schema;

namespace Disco.Domain.Models.Models
{
    public class Story : Base.BaseModel<int>
    {
        public List<StoryImage> StoryImages { get; set; } = new List<StoryImage>();
        public List<StoryVideo> StoryVideos { get; set;} = new List<StoryVideo>();

        [Column(TypeName = "date")]
        public DateTime DateOfCreation { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
