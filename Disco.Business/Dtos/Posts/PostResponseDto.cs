using Disco.Domain.Models;

namespace Disco.Business.Dtos.Posts
{
    public class PostResponseDto
    {
        public Post Post { get; set; }
        public string VarificationResult { get; set; }
    }
}
