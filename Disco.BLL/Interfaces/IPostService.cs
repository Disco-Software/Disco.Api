using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.BLL.Models.Posts;
using Disco.DAL.Entities;
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
        Task<IActionResult> CreatePostAsync(CreatePostModel model);
        Task<ActionResult<List<Post>>> GetAllUserPosts(int userId);
        Task<ActionResult<List<Post>>> GetAllPosts(int userId);
        Task DeletePostAsync(int postId);
    }
}
