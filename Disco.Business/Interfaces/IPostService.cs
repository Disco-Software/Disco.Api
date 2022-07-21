using Disco.Business.Dtos.Posts;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IPostService
    {
        Task<IActionResult> CreatePostAsync(CreatePostDto model);
        Task<ActionResult<List<Post>>> GetAllUserPosts(GetAllPostsDto model);
        Task<ActionResult<List<Post>>> GetAllPosts(GetAllPostsDto model);
        Task DeletePostAsync(int postId);
    }
}
