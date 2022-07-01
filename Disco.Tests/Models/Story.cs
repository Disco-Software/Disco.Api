using System;
using System.Collections.Generic;

namespace Disco.Tests.Models
{
    public class Story
    {
        public int Id { get; set; }
        public List<StoryImage> StoryImages { get; set; } = new List<StoryImage>();
        public List<StoryVideo> StoryVideos { get; set; } = new List<StoryVideo>();
        public DateTime DateOfCreation { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

    }
}