using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Dto.Songs;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class SongService : ISongService
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly IMapper mapper;
        private readonly ISongRepository songRepository;
        private readonly IPostRepository postRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public SongService(
            BlobServiceClient _blobServiceClient,
            IMapper _mapper,
            ISongRepository _songRepository,
            IPostRepository _postRepository,
            IHttpContextAccessor _httpContextAccessor)
        {
            songRepository = _songRepository;
            postRepository = _postRepository;
            blobServiceClient = _blobServiceClient;
            mapper = _mapper;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<PostSong> CreatePostSongAsync(CreateSongDto model)
        {
            var post = await postRepository.Get(model.PostId);
            
            var uniqueSongName = Guid.NewGuid().ToString() + "_" + model.SongFile.FileName.Replace(' ', '_');
            var uniqueImageName = Guid.NewGuid().ToString() + "_" + model.SongImage.FileName.Replace(' ', '_');
           
            if (model.SongFile == null)
                return null;

            if (model.SongFile.Length == 0)
                return null;

            var blobSongContainerClient = blobServiceClient.GetBlobContainerClient("songs");
            var blobImageContainerClient = blobServiceClient.GetBlobContainerClient("images");
           
            var blobSongClient = blobSongContainerClient.GetBlobClient(uniqueSongName);
            var blobImageClient = blobImageContainerClient.GetBlobClient(uniqueImageName);

            using var songReader = model.SongFile.OpenReadStream();
            var blobSongResult = blobSongClient.Upload(songReader);

            using var imageReader = model.SongImage.OpenReadStream();
            var blobImageResult = blobImageClient.Upload(imageReader);

            var song = mapper.Map<PostSong>(model);
            song.ImageUrl = blobImageClient.Uri.AbsoluteUri;
            song.Source = blobSongClient.Uri.AbsoluteUri;
            song.Name = model.Name;

            await songRepository.AddAsync(song);

            return song;
        }

        public async Task Remove(int songId)
        {
            await songRepository.Remove(songId);
        }
    }
}
