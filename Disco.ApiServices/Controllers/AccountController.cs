using AutoMapper;
using Disco.ApiServices.Validators;
using Disco.Business.Constants;
using Disco.Business.Dtos.Apple;
using Disco.Business.Dtos.Authentication;
using Disco.Business.Dtos.Facebook;
using Disco.Business.Dtos.Google;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Route("api/user/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly ITokenService _tokenService;
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly IMapper _mapper;

        public AccountController(
            IAccountService accountService,
            IAccountPasswordService accountPasswordService,
            IAccountDetailsService accountDetailsService,
            ITokenService tokenService,
            IFacebookAuthService facebookAuthService,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
            _accountPasswordService = accountPasswordService;
            _tokenService = tokenService;
            _facebookAuthService = facebookAuthService;
            _mapper = mapper;
        }

        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn([FromBody] LoginDto dto)
        {
            var validator = await LogInValidator
                .Create(_accountService)
                .ValidateAsync(dto);

            if (!validator.IsValid)
                return BadRequest(validator.Errors);

            var user = await _accountService.GetByEmailAsync(dto.Email);

            var passwordResponse = await _accountPasswordService.VerifyPasswordAsync(user, dto.Password);
            if(passwordResponse == PasswordVerificationResult.Failed)
            {
                return BadRequest("Not valid password");
            }

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _accountService.SaveRefreshTokenAsync(user,refreshToken);

            var responseDto = _mapper.Map<UserResponseDto>(user);
            responseDto.AccessToken = accessToken;
            responseDto.RefreshToken = refreshToken;
            responseDto.User = user;

            return Ok(responseDto);
        }

        [HttpPost("log-in/facebook")]
        public async Task<IActionResult> Facebook([FromBody] FacebookRequestDto dto)
        {
            var validator = await FacebookAccessTokenValidator
                .Create()
                .ValidateAsync(dto);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            var userInfo = await _facebookAuthService.GetUserInfo(dto.AccessToken);

            var user = await _accountService.GetByEmailAsync(userInfo.Email);
            if(user != null)
            {
                user.Email = userInfo.Email;
                user.UserName = userInfo.Name;
                user.Profile.Photo = userInfo.Picture.Data.Url;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                _accountService.SaveRefreshTokenAsync(user,refreshToken);

                var userRsponseDto = _mapper.Map<UserResponseDto>(user);
                userRsponseDto.AccessToken = accessToken;
                userRsponseDto.RefreshToken = refreshToken;
                userRsponseDto.User = user;

                return Ok(userRsponseDto);
            }

            user = await _accountService.GetByLogInProviderAsync(LogInProvider.Facebook, userInfo.Id);
            if(user != null)
            {
                user.Email = userInfo.Email;
                user.UserName = userInfo.Name;
                user.Profile.Photo = userInfo.Picture.Data.Url;

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var userRsponseDto = _mapper.Map<UserResponseDto>(user);
                userRsponseDto.AccessToken = accessToken;
                userRsponseDto.RefreshToken = refreshToken;
                userRsponseDto.User = user;

                return Ok(userRsponseDto);
            }

            var registeredUser = await _accountService.CreateAsync(new Domain.Models.User
            {
                UserName = userInfo.Name,
                DateOfRegister = DateTime.UtcNow,
                Email = userInfo.Email,
                Profile = new Domain.Models.Account
                {
                    Status = StatusTypes.NewArtist,
                    User = user,
                    Photo = userInfo.Picture.Data.Url,
                }
            });

            user = await _accountService.CreateAsync(registeredUser);

            var userAccessToken = _tokenService.GenerateAccessToken(user);
            var userRefreshToken = _tokenService.GenerateRefreshToken();

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
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _accountService.SaveRefreshTokenAsync(user, refreshToken);

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken= refreshToken;
                userResponseDto.User = user;

                return Ok(userResponseDto);
            }

            var registeredUser = await _accountService.CreateAsync(new Domain.Models.User
            {
                UserName = dto.UserName,
                DateOfRegister = DateTime.UtcNow,
                Email = dto.Email,
                Profile = new Domain.Models.Account
                {
                    Status = StatusTypes.NewArtist,
                    User = user,
                    Photo = dto.Photo,
                }
            });

            user = await _accountService.CreateAsync(registeredUser);

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
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var userResponseDto = _mapper.Map<UserResponseDto>(user);
                userResponseDto.AccessToken = accessToken;
                userResponseDto.RefreshToken = refreshToken;
                userResponseDto.User = user;

                return Ok(userResponseDto);
            }

            user = await _accountService.CreateAsync(new Domain.Models.User
            {
                UserName = dto.Name,
                DateOfRegister = DateTime.UtcNow,
                Email = dto.Email,
                Profile = new Domain.Models.Account
                {
                    Status = StatusTypes.NewArtist,
                    User = user,
                }
            });

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
        public async Task<IActionResult> Registration([FromBody] RegistrationDto model)
        {
            var validator = await RegistrationValidator
                .Create(_accountService)
                .ValidateAsync(model);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            var user = _mapper.Map<User>(model);
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Profile = new Domain.Models.Account
            {
                User = user,
                UserId = user.Id,
                Status = StatusTypes.NewArtist
            };

            _accountService.GetUserRole(user);

            user = await _accountService.CreateAsync(user);

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
