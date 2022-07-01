namespace Disco.Tests.Models
{
    public class StoryVideo
    {
        public string Source { get; set; }

        public int StoryId { get; set; }
        public Story Story { get; set; }

    }
}