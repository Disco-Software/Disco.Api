using AutoMapper;
using Disco.Business.Interfaces.Validators;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Apple;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Dtos.Facebook;
using Disco.Business.Interfaces.Dtos.Google;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Route("api/user/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly ITokenService _tokenService;
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly IMapper _mapper;

        public AccountController(
            IAccountService accountService,
            IAccountPasswordService accountPasswordService,
            ITokenService tokenService,
            IFacebookAuthService facebookAuthService,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
            _tokenService = tokenService;
            _facebookAuthService = facebookAuthService;
            _mapper = mapper;
        }

        [HttpPost("log-in")]
        public async Task<IActionResult> LogInAsync([FromBody] LoginDto dto)
        {
            var user = await _accountService.GetByEmailAsync(dto.Email);

            var passwordResponse = _accountPasswordService.VerifyPasswordAsync(user, dto.Password);
            if(passwordResponse == PasswordVerificationResult.Failed)
            {
                return BadRequest("Not valid password");
            }

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user,refreshToken);

            var responseDto = _mapper.Map<UserResponseDto>(user);
            responseDto.AccessToken = accessToken;

            return Ok(responseDto);
        }

        [HttpPost("log-in/facebook")]
        public async Task<IActionResult> Facebook([FromBody] FacebookRequestDto dto)
        {
            var userInfo = await _facebookAuthService.GetUserInfo(dto.AccessToken);
            userInfo.Name = userInfo.Name.Replace(" ", "_");

            var user = await _accountService.GetByLogInProviderAsync(LogInProvider.Facebook, userInfo.Id);
            if (user != null)
            {
                user.Email = userInfo.Email;
                user.UserName = userInfo.Name;
                user.Account.Photo = userInfo.Picture.Data.Url;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var userRsponseDto = _mapper.Map<UserResponseDto>(user);
                userRsponseDto.AccessToken = accessToken;
                userRsponseDto.RefreshToken = refreshToken;
                userRsponseDto.User = user;

                return Ok(userRsponseDto);
            }


            user = await _accountService.GetByEmailAsync(userInfo.Email);
            if (user != null)
            {
                user.Email = userInfo.Email;
                user.UserName = userInfo.Name;
                user.Account.Photo = userInfo.Picture.Data.Url;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user,refreshToken);

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken = refreshToken;
                userResponseDto.User = user;

                return Ok(userResponseDto);
            }

            user = new Domain.Models.Models.User
            {
                UserName = userInfo.Name,
                DateOfRegister = DateTime.UtcNow,
                Email = userInfo.Email,
                Account = new Domain.Models.Models.Account
                {
                    User = user,
                    Photo = userInfo.Picture.Data.Url,
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>()
                }
            };

            await _accountService.CreateAsync(user);

            var userAccessToken = _tokenService.GenerateAccessToken(user);
            var userRefreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, userRefreshToken);

            var userRegisterResponseDto = _mapper.Map<UserResponseDto>(user);
            userRegisterResponseDto.RefreshToken = userRefreshToken;
            userRegisterResponseDto.User = user;
            userRegisterResponseDto.AccessToken = userAccessToken;

            return Ok(userRegisterResponseDto);
        }

        [HttpPost("log-in/google")]
        public async Task<IActionResult> Google([FromBody] GoogleLogInDto dto)
        {
            var user = await _accountService.GetByEmailAsync(dto.Email);
            if(user != null)
            {
                user.Email = dto.Email;
                user.UserName = dto.UserName;
                user.Account.Photo = dto.Photo;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken = refreshToken;
                userResponseDto.User = user;

                return Ok(userResponseDto);
            }

            user = await _accountService.GetByLogInProviderAsync(LogInProvider.Google, dto.IdToken);
            if(user != null)
            {
                user.Account.Photo = dto.Photo;
                user.UserName = dto.UserName;
                user.Email = dto.Email;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken= refreshToken;
                userResponseDto.User = user;

                return Ok(userResponseDto);
            }

            user = new Domain.Models.Models.User
            {
                UserName = dto.UserName,
                DateOfRegister = DateTime.UtcNow,
                Email = dto.Email,
                Account = new Domain.Models.Models.Account
                {
                    User = user,
                    Photo = dto.Photo,
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Posts = new List<Post>(),
                    Stories = new List<Story>(),
                    UserId = user.Id
                }
            };

            await _accountService.CreateAsync(user);

            var userAccessToken = _tokenService.GenerateAccessToken(user);
            var userRefreshToken = _tokenService.GenerateRefreshToken();

            var userRegisterResponseDto = _mapper.Map<UserResponseDto>(user);
            userRegisterResponseDto.RefreshToken = userRefreshToken;
            userRegisterResponseDto.User = user;
            userRegisterResponseDto.AccessToken = userAccessToken;

            return Ok(user);
        }

        [HttpPost("log-in/apple")]
        public async Task<IActionResult> Apple([FromBody] AppleLogInDto dto)
        {
            var user = await _accountService.GetByEmailAsync(dto.Email);
            if(user != null)
            {
                user.Email = dto.Email;
                user.UserName = dto.Name;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken = refreshToken;
                userResponseDto.User = user;

                return Ok(userResponseDto);
            }

            user = await _accountService.GetByLogInProviderAsync(LogInProvider.Apple, dto.AppleIdCode);
            if(user != null)
            {
                user.Email = dto.Email;
                user.UserName = dto.Name;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken = refreshToken;
                userResponseDto.User = user;

                return Ok(userResponseDto);
            }

            user = new Domain.Models.Models.User
            {
                UserName = dto.Name,
                DateOfRegister = DateTime.UtcNow,
                Email = dto.Email,
                Account = new Domain.Models.Models.Account
                {
                    User = user,
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Posts = new List<Post>(),
                    Stories = new List<Story>(),
                }
            };
            
            await _accountService.CreateAsync(user);

            var userAccessToken = _tokenService.GenerateAccessToken(user);
            var userRefreshToken = _tokenService.GenerateRefreshToken();

            var userRegisterResponseDto = _mapper.Map<UserResponseDto>(user);
            userRegisterResponseDto.RefreshToken = userRefreshToken;
            userRegisterResponseDto.User = user;
            userRegisterResponseDto.AccessToken = userAccessToken;

            return Ok(user);
        }

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
        {
            var user = await _accountService.GetByRefreshTokenAsync(dto.RefreshToken);

            if (user == null)
                return BadRequest();

            if(user.RefreshTokenExpiress >= DateTime.UtcNow.AddDays(7))
            {
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user,refreshToken);

                var userRefreshedResponseDto = _mapper.Map<UserResponseDto>(user);
                userRefreshedResponseDto.AccessToken = accessToken;
                userRefreshedResponseDto.RefreshToken = refreshToken;
                userRefreshedResponseDto.User = user;

                return Ok(userRefreshedResponseDto);
            }
            
            var accessResponseToken = _tokenService.GenerateAccessToken(user);

            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            userResponseDto.AccessToken = accessResponseToken;
            userResponseDto.RefreshToken = user.RefreshToken;
            userResponseDto.User = user;

            return Ok(userResponseDto);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationDto dto)
        {
            var user = _mapper.Map<User>(dto);
            
            user.Email = dto.Email;
            user.UserName = dto.UserName;
            user.Account = new Domain.Models.Models.Account();
            user.Account.User = user;
            user.Account.Id = user.Id;
            user.Account.Followers = new List<UserFollower>();
            user.Account.Following = new List<UserFollower>();
            user.Account.Posts = new List<Post>();
            user.Account.Stories = new List<Story>();

            await _accountService.CreateAsync(user);

            _accountPasswordService.AddPasswod(user, dto.Password);

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user, refreshToken);

            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            userResponseDto.RefreshToken = refreshToken;
            userResponseDto.AccessToken = accessToken;
            userResponseDto.User = user;

            return Ok(userResponseDto);
        }
    }
}
