using AutoMapper;
using Disco.Business.Interfaces.Dtos.Images;
using Disco.Business.Interfaces.Dtos.Songs;
using Disco.Business.Interfaces.Dtos.Videos;
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

namespace Disco.ApiServices.Features.Post.RequestHandlers.CreatePost
{
    public class CreatePostRequestHandler : IRequestHandler<CreatePostRequest, Domain.Models.Models.Post>
    {
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        private readonly IImageService _imageService;
        private readonly ISongService _songService;
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public CreatePostRequestHandler(
            IAccountService accountService,
            IPostService postService, 
            IImageService imageService, 
            ISongService songService, 
            IVideoService videoService, 
            IMapper mapper, 
            IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _postService = postService;
            _imageService = imageService;
            _songService = songService;
            _videoService = videoService;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<Domain.Models.Models.Post> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var post = _mapper.Map<Domain.Models.Models.Post>(request.Dto);
            post.Account = user.Account;
            post.AccountId = user.AccountId;
            post.Description = request.Dto.Description;
            post.DateOfCreation = System.DateTime.UtcNow;

            if (request.Dto.PostImages != null)
            {
                foreach (var image in request.Dto.PostImages.ToList())
                {
                    var postImageDto = _mapper.Map<CreateImageDto>(request.Dto);
                    postImageDto.ImageFile = image;

                    var postImage = await _imageService.CreatePostImage(postImageDto);
                    postImage.Post = post;
                    postImage.PostId = post.Id;

                    post.PostImages.Add(postImage);

                    request.Dto.PostImages.Remove(image);
                }
            }
            if (request.Dto.PostSongs != null)
            {
                foreach (var song in request.Dto.PostSongs.ToList())
                {
                    var name = request.Dto.PostSongNames.First();
                    var artist = request.Dto.ExecutorNames.First();
                    var songSource = request.Dto.PostSongs.First();
                    var songImage = request.Dto.PostSongImages.First();

                    var postSongDto = _mapper.Map<CreateSongDto>(request.Dto);
                    postSongDto.Name = name;
                    postSongDto.ExecutorName = artist;
                    postSongDto.Post = post;
                    postSongDto.Image = songImage;
                    postSongDto.Song = songSource;

                    var postSong = await _songService.CreatePostSongAsync(postSongDto);

                    request.Dto.PostSongNames.Remove(name);
                    request.Dto.ExecutorNames.Remove(artist);
                    request.Dto.PostSongs.Remove(songSource);
                    request.Dto.PostSongImages.Remove(songImage);
                }
            }

            if (request.Dto.PostVideos != null)
            {
                foreach (var video in request.Dto.PostVideos.ToList())
                {
                    var postVideoDto = _mapper.Map<CreateVideoDto>(request.Dto);
                    postVideoDto.VideoFile = video;

                    var postVideo = await _videoService.CreateVideoAsync(postVideoDto);

                    request.Dto.PostImages.Remove(video);
                }
            }

            await _postService.CreatePostAsync(post);

            return post;
        }
    }
}
