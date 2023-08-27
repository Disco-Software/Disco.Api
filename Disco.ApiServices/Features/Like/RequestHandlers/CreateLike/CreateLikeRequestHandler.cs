using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Like.RequestHandlers.CreateLike
{
    public class CreateLikeRequestHandler : IRequestHandler<CreateLikeRequest, int>
    {
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        private readonly ILikeService _likeService;
        private readonly IHttpContextAccessor _contextAccessor;

        public CreateLikeRequestHandler(
            IAccountService accountService, 
            IPostService postService, 
            ILikeService likeService, 
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _postService = postService;
            _likeService = likeService;
            _contextAccessor = contextAccessor;
        }

        public async Task<int> Handle(CreateLikeRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);
            var post = await _postService.GetPostAsync(request.PostId);

            if (user == null)
            {
                throw new ResourceNotFoundException(new Dictionary<string, string>
                {
                    {"user", "User claim not found" }
                });
            }

            var likes = await _likeService.AddLikeAsync(user, post);

            //await _pushNotificationService.SendNotificationAsync(new Business.Dtos.PushNotifications.LikeNotificationDto
            //{
            //    Title = $"{user.UserName} liked ",
            //    Body = $"{user.UserName} liked your post",
            //    Id = Guid.NewGuid().ToString(),
            //    Tags = $"user-{post.Account.User.Id}",
            //    LikesCount = likes.Count,
            //    NotificationType = NotificationTypes.LikeNotification
            //});

            return likes.Count;
        }
    }
}
