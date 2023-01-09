using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Hubs
{
     public class CommentHub : Hub
    {
        private readonly IAccountService _accountService;
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public CommentHub(
            IAccountService accountService,
            ICommentService commentService,
            IPostService postService,
            IMapper mapper)
        {
            _accountService = accountService;
            _commentService = commentService;
            _postService = postService;
            _mapper = mapper;
        }

        public async Task SendCommentAsync(string message, int userId, int postId)
        {
            var user = await _accountService.GetByIdAsync(userId);
            var post = await _postService.GetPostAsync(postId);

            var comment = _mapper.Map<Comment>(post);
            comment.Post = post;
            comment.PostId = post.Id;
            comment.CommentDescription = message;
            comment.Account = user.Account;
            comment.AccountId = user.AccountId;

            await _commentService.AddCommentAsync(comment);

            await Clients.All.SendAsync("sendCommentAsync", user, post);
        }

        public async Task RemoveCommentAsync(int commentId, int postId, int userId)
        {
            var post = await _postService.GetPostAsync(postId);
            var user = await _accountService.GetByIdAsync(userId);
            var comment = await _commentService.GetCommentAsync(commentId);

            await _commentService.RemoveCommentAsync(comment);

            await Clients.All.SendAsync("RemoveCommentAsync", user, comment, post);
        }
    }
}
