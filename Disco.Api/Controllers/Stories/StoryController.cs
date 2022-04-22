﻿using Disco.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System.Web.Http;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using Disco.BLL.Constants;
using System.Threading.Tasks;
using Disco.DAL.Entities;
using Disco.BLL.Models.Stories;
using System.Collections.Generic;

namespace Disco.Api.Controllers.Stories
{
    [Route("api/user/story")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class StoryController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public StoryController(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;

        [Microsoft.AspNetCore.Mvc.HttpPost("create")]
        public async Task<Story> Create([FromForm] CreateStoryModel model) =>
            await serviceManager.StoryService.CreateStoryAsync(model);  

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id:int}")]
        public async Task Delete([FromRoute] int id) =>
            await serviceManager.StoryService.DeleteStoryAsync(id);

        [Microsoft.AspNetCore.Mvc.HttpGet("get/{id:int}")]
        public async Task<Story> GetStory([FromRoute] int id) =>
            await serviceManager.StoryService.GetStoryAsync(id);

        [Microsoft.AspNetCore.Mvc.HttpGet("all/{id:int}")]
        public async Task<List<Story>> GetStoriesAsync([FromRoute] int id) =>
            await serviceManager.StoryService.GetAllStoryAsync(id);

    }
}