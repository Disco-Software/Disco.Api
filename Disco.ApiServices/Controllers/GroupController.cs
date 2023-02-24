using Disco.Business.Constants;
using Disco.Business.Dtos.Chat;
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
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthSchema.UserToken)]
    [Route("api/user/groups")]
    public class GroupController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IGroupService _groupService;
        private readonly IAccountGroupService _accountGroupService;

        public GroupController(
            IAccountService accountService,
            IGroupService groupService,
            IAccountGroupService accountGroupService)
        {
            _accountService = accountService;
            _groupService = groupService;
            _accountGroupService = accountGroupService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateGroupRequestDto dto)
        {
            var currentUser = await _accountService.GetAsync(HttpContext.User);
            var user = await _accountService.GetByIdAsync(dto.UserId);

            var group = await _groupService.CreateAsync();

            var currentUserAccountGroup = await _accountGroupService.CreateAsync(currentUser.Account, group);
            var userAccountGroup = await _accountGroupService.CreateAsync(user.Account, group);

            return Ok(group);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
           [FromQuery] int pageNumber, 
           [FromQuery] int pageSize)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

            var groups = await _groupService.GetAllAsync(user.Id, pageNumber, pageSize);

            return Ok(groups);
        }

        [HttpDelete("{groupId:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int groupId)
        {
            var user = await _accountService.GetAsync(HttpContext.User);
            var group = await _groupService.GetAsync(groupId);

            await _groupService.DeleteAsync(group, user.Account);

            return Ok("this group was removed");
        }
    }
}
