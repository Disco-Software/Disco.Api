using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Dtos.Search;
using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private readonly IAccountDetailsService _accountService;
        public GlobalSearchController(
            IPostService postService, 
            IAccountDetailsService profileService)
        {
            _postService = postService;
            _accountService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> Serach([FromQuery] string search)
        {
            var accounts = await _accountService.GetAccountsByNameAsync(search);
            var posts = await _postService.SearchPostsAsync(search);

            var searchResponseDto = new GlobalSearchResponseDto();
            searchResponseDto.Posts = posts;
            searchResponseDto.Accounts = accounts;

            return Ok(searchResponseDto);
        }
    }
}
