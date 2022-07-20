using AutoMapper;
using Azure.Storage.Blobs;
using Disco.BLL.Interfaces;
using Disco.BLL.Dto.Songs;
using Disco.DAL.EF;
using Disco.DAL.Models;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class SongService : ISongService
    {
        private readonly SongRepository songRepository;
        private readonly PostRepository postRepository;
        private readonly BlobServiceClient blobServiceClient;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public SongService(
            SongRepository _songRepository, 
            PostRepository _postRepository,
            BlobServiceClient _blobServiceClient,
            IMapper _mapper,
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

            await songRepository.Add(song);

            return song;
        }

        public async Task Remove(int songId)
        {
            await songRepository.Remove(songId);
        }
    }
}
