using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Apple;
using Disco.Business.Dtos.Authentication;
using Disco.Business.Dtos.EmailNotifications;
using Disco.Business.Dtos.Facebook;
using Disco.Domain.Models;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Business.Dtos.Google;

namespace Disco.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        public AuthenticationService(
            UserManager<User> userManager,
            BlobServiceClient blobServiceClient,
            IUserService userService,
            ITokenService tokenService,
            IEmailService emailService,
            IMapper mapper)
        {
            _userManager = userManager;
            _blobServiceClient = blobServiceClient;
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        public async Task<UserResponseDto> LogIn(User user, string password)
        {
            var jwt = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _userService.SaveRefreshTokenAsync(user, refreshToken);

            var userResponseModel = _mapper.Map<UserResponseDto>(user);
            userResponseModel.RefreshToken = refreshToken;
            userResponseModel.AccessToken = jwt;
            userResponseModel.User = user;

            return userResponseModel;
        }

        public async Task<UserResponseDto> Register(RegistrationDto dto)
        {
            var userResult = _mapper.Map<User>(dto);

            userResult.PasswordHash = _userManager.PasswordHasher.HashPassword(userResult, dto.Password);
            userResult.Profile = new Domain.Models.Profile { Status = StatusTypes.NewArtist };
            userResult.NormalizedEmail = _userManager.NormalizeEmail(userResult.Email);
            userResult.NormalizedUserName = _userManager.NormalizeName(userResult.UserName);
            userResult.RefreshToken = _tokenService.GenerateRefreshToken();
            userResult.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

            var identityResult = await _userManager.CreateAsync(userResult);
            if (!identityResult.Succeeded)
                throw new Exception(identityResult.Errors.First().Description);

            var roleResult = await _userManager.AddToRoleAsync(userResult, UserRole.User);
            if (!roleResult.Succeeded)
                throw new Exception(roleResult.Errors.First().Description);

            userResult.RoleName = _userService.GetUserRole(userResult);

            var jwt = _tokenService.GenerateAccessToken(userResult);

            var userResponseModel = _mapper.Map<UserResponseDto>(userResult);
            userResponseModel.RefreshToken = userResult.RefreshToken;
            userResponseModel.AccessToken = jwt;
            userResponseModel.User = userResult;

            return userResponseModel;
        }

        public async Task<UserResponseDto> Facebook(FacebookDto dto)
        {
            var user = await _userManager.FindByLoginAsync(LogInProvider.Facebook, dto.Id);
            if (user != null)
            {
                await _userService.LoadUserInfoAsync(user);
                user.RoleName = _userService.GetUserRole(user);

                user.Email = dto.Email;
                user.UserName = dto.FirstName;
                user.Profile.Photo = dto.Picture.Data.Url;

                await _userManager.UpdateAsync(user);

                var jwt = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var userResponseModel = _mapper.Map<UserResponseDto>(user);
                userResponseModel.AccessToken = jwt;
                userResponseModel.RefreshToken = refreshToken;
                userResponseModel.User = user;

                return userResponseModel;
            }

            user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null)
            {
                await _userService.LoadUserInfoAsync(user);
                user.RoleName = _userService.GetUserRole(user);

                await _userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Facebook, dto.Id, "FacebookId"));

                var jwt = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var userResponseModel = _mapper.Map<UserResponseDto>(user);
                userResponseModel.RefreshToken = refreshToken;
                userResponseModel.AccessToken = jwt;
                userResponseModel.User = user;

                return userResponseModel;
            }

            user = new User
            {
                UserName = dto.Name.Replace(" ", "_"),
                Email = dto.Email,
                NormalizedEmail = _userManager.NormalizeEmail(dto.Email),
                NormalizedUserName = _userManager.NormalizeName(dto.Name),
                Profile = new Domain.Models.Profile
                {
                    Status = StatusTypes.NewArtist,
                    Photo = dto.Picture.Data.Url
                },
                RefreshToken = _tokenService.GenerateRefreshToken(),
                RefreshTokenExpiress = DateTime.UtcNow.AddDays(7)
            };

            user.NormalizedEmail = _userManager.NormalizeEmail(user.Email);
            user.NormalizedUserName = _userManager.NormalizeName(user.UserName);

            _ = await _userManager.CreateAsync(user);

            _ = await _userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Facebook, dto.Id, "FacebookId"));

            _ = await _userManager.AddToRoleAsync(user, UserRole.User);

            user.RoleName = _userService.GetUserRole(user);

            var jwtToken = _tokenService.GenerateAccessToken(user);

            var userResponse = _mapper.Map<UserResponseDto>(user);
            userResponse.AccessToken = jwtToken;
            userResponse.RefreshToken = user.RefreshToken;
            userResponse.User = user;

            return userResponse;
        }

        public async Task<UserResponseDto> RefreshToken(User user, RefreshTokenDto model)
        {
            if (user.RefreshTokenExpiress >= DateTime.UtcNow)
            {
                await _userService.SaveRefreshTokenAsync(user, model.RefreshToken);

                var jwtToken = _tokenService.GenerateAccessToken(user);

                var userResponseModel = _mapper.Map<UserResponseDto>(user);
                userResponseModel.RefreshToken = user.RefreshToken;
                userResponseModel.AccessToken = jwtToken;
                userResponseModel.User = user;

                return userResponseModel;
            }

            var jwt = _tokenService.GenerateAccessToken(user);

            var userResponse = _mapper.Map<UserResponseDto>(user);
            userResponse.RefreshToken = user.RefreshToken;
            userResponse.AccessToken = jwt;
            userResponse.User = user;

            return userResponse;
        }

        public async Task<UserResponseDto> Apple(AppleLogInDto model)
        {
            User user;
            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    user.UserName = model.Name;

                    await _userService.SaveRefreshTokenAsync(user, user.RefreshToken);

                    await _userManager.UpdateAsync(user);

                    var jwtToken = _tokenService.GenerateAccessToken(user);

                    var userResponseModel = _mapper.Map<UserResponseDto>(user);
                    userResponseModel.RefreshToken = user.RefreshToken;
                    userResponseModel.AccessToken = jwtToken;
                    userResponseModel.User = user;

                    return userResponseModel;
                }

                user = await _userManager.FindByLoginAsync(LogInProvider.Apple, model.Name);
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.Email = model.Email;
                    user.RefreshToken = _tokenService.GenerateRefreshToken();

                    await _userService.SaveRefreshTokenAsync(user, user.RefreshToken);

                    await _userManager.UpdateAsync(user);

                    var jwtToken = _tokenService.GenerateAccessToken(user);

                    var userResponseResult = _mapper.Map<UserResponseDto>(user);
                    userResponseResult.RefreshToken = user.RefreshToken;
                    userResponseResult.AccessToken = jwtToken;
                    userResponseResult.User = user;

                    return userResponseResult;
                }

                user = new User
                {
                    UserName = model.Name,
                    Email = model.Email,
                    NormalizedEmail = _userManager.NormalizeEmail(model.Email),
                    NormalizedUserName = _userManager.NormalizeName(model.Name)
                };

                var profile = new Domain.Models.Profile
                {
                    User = user,
                    UserId = user.Id,
                    Status = StatusTypes.NewArtist,
                };
                user.Profile = profile;

                await _userService.SaveRefreshTokenAsync(user, user.RefreshToken);

                _ = await _userManager.CreateAsync(user);

                _ = await _userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Apple, model.AppleId, "AppleId"));

                var jwt = _tokenService.GenerateAccessToken(user);

                var userResponse = _mapper.Map<UserResponseDto>(user);
                userResponse.RefreshToken = user.RefreshToken;
                userResponse.AccessToken = jwt;
                userResponse.User = user;

                return userResponse;

            }
            return null;
        }

        public async Task<string> ForgotPassword(User user)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("templates");
            var blobClient = blobContainerClient.GetBlobClient("index.html");

            var uri = blobClient.Uri.AbsoluteUri;

            var html = (new WebClient()).DownloadString(uri);
            var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = $"disco://disco.app/token/{passwordToken}";

            var model = new EmailConfirmationDto
            {
                MessageHeader = "Email confirmation",
                MessageBody = html.Replace("[token]", passwordToken).Replace("[email]", user.Email),
                ToEmail = user.Email,
                IsHtmlTemplate = true
            };

            _emailService.EmailConfirmation(model);
            return passwordToken;
        }

        public async Task<UserResponseDto> ResetPassword(User user, ResetPasswordDto model)
        {
            var identityResult = await _userManager.ResetPasswordAsync(user, model.ConfirmationToken, model.Password);
            if (!identityResult.Succeeded)
                throw new Exception($"You have sum errors {identityResult.Errors}");

            return new UserResponseDto
            {
                User = user,
                RefreshToken = _tokenService.GenerateRefreshToken(),
                AccessToken = _tokenService.GenerateAccessToken(user)
            };
        }

        public async Task<UserResponseDto> Google(GoogleLogInDto dto)
        {
            User user;
            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                user = await _userManager.FindByLoginAsync(LogInProvider.Google, dto.IdToken);
                if (user != null)
                {
                    user.UserName = dto.UserName;
                    user.Email = dto.Email;

                    await _userService.SaveRefreshTokenAsync(user, user.RefreshToken);

                    await _userManager.UpdateAsync(user);

                    var jwtToken = _tokenService.GenerateAccessToken(user);

                    var userResponseResult = _mapper.Map<UserResponseDto>(user);
                    userResponseResult.RefreshToken = user.RefreshToken;
                    userResponseResult.AccessToken = jwtToken;
                    userResponseResult.User = user;

                    return userResponseResult;
                }

                user = new User
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    NormalizedEmail = _userManager.NormalizeEmail(dto.Email),
                    NormalizedUserName = _userManager.NormalizeName(dto.UserName)
                };

                var profile = new Domain.Models.Profile
                {
                    User = user,
                    UserId = user.Id,
                    Status = StatusTypes.NewArtist,
                };
                user.Profile = profile;

                _ = await _userManager.CreateAsync(user);

                _ = await _userManager.AddLoginAsync(user, new UserLoginInfo(LogInProvider.Google, dto.IdToken, "GoogleIdToken"));

                await _userManager.AddToRoleAsync(user, UserRole.User);
                user.RoleName = _userService.GetUserRole(user);

                var jwt = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                await _userService.SaveRefreshTokenAsync(user, refreshToken);

                var userResponse = _mapper.Map<UserResponseDto>(user);
                userResponse.RefreshToken = user.RefreshToken;
                userResponse.AccessToken = jwt;
                userResponse.User = user;

                return userResponse;
            }

            return null;
        }
    }
}
