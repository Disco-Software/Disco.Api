using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Disco.Business.Interfaces.Validators;
using AutoMapper;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.ApiServices.Controllers.Admin 
{

    [Route("api/admin/users")]
    [ApiController]
    [Authorize(
         AuthenticationSchemes = AuthSchema.UserToken,
         Roles = UserRole.Admin)]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserController(
            IAccountService accountService,
            IAccountDetailsService accountDetailsService,
            ITokenService tokenService,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RegistrationDto model)
        {
            var user = _mapper.Map<User>(model);
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Account = new Domain.Models.Models.Account
            {
                User = user,
                UserId = user.Id,
            };

            await _accountService.CreateAsync(user);

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, refreshToken);

            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            userResponseDto.RefreshToken = refreshToken;
            userResponseDto.AccessToken = accessToken;
            userResponseDto.User = user;

            return Ok(userResponseDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            var user = await _accountService.GetByIdAsync(id);
            if(user == null)
            {
                return BadRequest("User not found");
            }

            await _accountDetailsService.RemoveAsync(user.Account);
            await _accountService.RemoveAsync(user);

            return Ok("User was removed");
        }

        [HttpGet("periot")]
        public async Task<ActionResult<List<User>>> GetAccountsByPeriotAsync(int periot)
        {
            var users = await _accountService.GetAccountsByPeriotAsync(periot);

            return Ok(users);
        }
    }
}
