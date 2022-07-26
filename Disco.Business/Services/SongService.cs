using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Songs;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class SongService : ISongService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;
        private readonly IPostRepository _postRepository;

        public SongService(
            BlobServiceClient blobServiceClient,
            IMapper mapper,
            ISongRepository songRepository,
            IPostRepository postRepository)
        {
            _songRepository = songRepository;
            _postRepository = postRepository;
            _blobServiceClient = blobServiceClient;
            _mapper = mapper;
        }

        public async Task<PostSong> CreatePostSongAsync(CreateSongDto model)
        {
            var post = await _postRepository.Get(model.PostId);
            
            var uniqueSongName = Guid.NewGuid().ToString() + "_" + model.SongFile.FileName.Replace(' ', '_');
            var uniqueImageName = Guid.NewGuid().ToString() + "_" + model.SongImage.FileName.Replace(' ', '_');
           
            if (model.SongFile == null)
                return null;

            if (model.SongFile.Length == 0)
                return null;

            var blobSongContainerClient = _blobServiceClient.GetBlobContainerClient("songs");
            var blobImageContainerClient = _blobServiceClient.GetBlobContainerClient("images");
           
            var blobSongClient = blobSongContainerClient.GetBlobClient(uniqueSongName);
            var blobImageClient = blobImageContainerClient.GetBlobClient(uniqueImageName);

            using var songReader = model.SongFile.OpenReadStream();
            var blobSongResult = blobSongClient.Upload(songReader);

            using var imageReader = model.SongImage.OpenReadStream();
            var blobImageResult = blobImageClient.Upload(imageReader);

            var song = _mapper.Map<PostSong>(model);
            song.ImageUrl = blobImageClient.Uri.AbsoluteUri;
            song.Source = blobSongClient.Uri.AbsoluteUri;
            song.Name = model.Name;

            await _songRepository.AddAsync(song);

            return song;
        }

        public async Task Remove(int songId)
        {
            await _songRepository.Remove(songId);
        }
    }
}
