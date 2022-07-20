﻿using Disco.BLL.Constants;
using Disco.BLL.Interfaces;
using Disco.BLL.Dto;
using Disco.BLL.Dto.Posts;
using Disco.BLL.Services;
using Disco.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    [Route("api/user/posts")]
    public class UserPostController : Controller
    {
        private readonly IPostService postService;

        public UserPostController(IPostService _postService)
        {
            postService = _postService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreatePostDto model)
        {
            return await postService.CreatePostAsync(model);
        }

        [HttpDelete("{postId:int}")]
        public async Task Delete([FromRoute] int postId)
        {
            await postService.DeletePostAsync(postId);
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllUserPosts([FromQuery] GetAllPostsDto model)
        {
            return await postService.GetAllUserPosts(model);
        }

        [HttpGet("line")]
        public async Task<ActionResult<List<Post>>> GetAllPosts([FromQuery] GetAllPostsDto model)
        {
            return await postService.GetAllPosts(model);
        }
    }
}
