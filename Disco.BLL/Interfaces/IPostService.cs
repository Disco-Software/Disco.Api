using Disco.BLL.Dto;
using Disco.BLL.Dto;
using Disco.BLL.Dto.Posts;
using Disco.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IPostService
    {
        Task<IActionResult> CreatePostAsync(CreatePostDto model);
        Task<ActionResult<List<Post>>> GetAllUserPosts(GetAllPostsDto model);
        Task<ActionResult<List<Post>>> GetAllPosts(GetAllPostsDto model);
        Task DeletePostAsync(int postId);
    }
}
