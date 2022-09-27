﻿using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Dtos.Search;
using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [Route("api/user/global/search")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class GlobalSearchController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IProfileService _profileService;
        public GlobalSearchController(
            IPostService postService, 
            IProfileService profileService)
        {
            _postService = postService;
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> Serach([FromQuery] string search)
        {
            var users = await _profileService.GetProfilesByName(search);
            var posts = await _postService.SearchPostsAsync(search);

            var searchResponseDto = new GlobalSearchResponseDto();
            searchResponseDto.Posts = posts;
            searchResponseDto.Profile = users;

            return Ok(searchResponseDto);
        }
    }
}
