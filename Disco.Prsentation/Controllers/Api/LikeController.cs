﻿using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Presentation.Controllers
{
    [Route("api/user/likes")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class LikeController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILikeService _likeService;
        private readonly IPostService _postService;
        private readonly IPushNotificationService _pushNotificationService;

        public LikeController(
            IUserService userService, 
            ILikeService likeService,
            IPostService postService,
            IPushNotificationService pushNotificationService)
        {
            _userService = userService;
            _likeService = likeService;
            _postService = postService;
            _pushNotificationService = pushNotificationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateLikeAsync([FromQuery] int postId)
        {
            var user = await _userService.GetUserAsync(User);
            var post = await _postService.GetPostAsync(postId);

            if (user == null)
            {
                return BadRequest();
            }

            var likes = await _likeService.AddLikeAsync(user, postId);

            await _pushNotificationService.SendNotificationAsync(new Business.Dtos.PushNotifications.LikeNotificationDto
            {
                Title = $"{user.UserName} liked ",
                Body = $"{user.UserName} liked your post",
                Id = Guid.NewGuid().ToString(),
                Tags = $"user-{post.Profile.User.Id}",
                LikesCount = likes.Count,
                NotificationType = NotificationTypes.LikeNotification
            });

            return Ok(likes.Count);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveLikeAsync([FromQuery] int postId)
        {
            var user = await _userService.GetUserAsync(User);
            var post = await _postService.GetPostAsync(postId);

            if (user == null)
            {
                return BadRequest();
            }

            var likes = await _likeService.RemoveLikeAsync(user, postId);

            return Ok(likes.Count);
        }
    }
}
