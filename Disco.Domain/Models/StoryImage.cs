namespace Disco.Domain.Models
{
    public class StoryImage : Base.BaseEntity<int>
    {
        public string Source { get; set; }

        public int StoryId { get; set; }
        public Story Story { get; set; }
    }
}
