﻿using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            comment.Post.Comments.Add(comment);
            comment.Account.Comments.Add(comment);

            await _commentRepository.AddAsync(comment);
        }

        public async Task RemoveCommentAsync(Comment comment)
        {
            comment.Post.Comments.Remove(comment);
            comment.Account.Comments.Remove(comment);

            await _commentRepository.Remove(comment.Id);
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
            return await _commentRepository.GetAsync(id);
        }
    }
}