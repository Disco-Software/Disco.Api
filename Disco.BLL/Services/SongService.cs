using Azure.Storage.Blobs;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.Songs;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
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
        public SongService(
            SongRepository _songRepository, 
            PostRepository _postRepository,
            BlobServiceClient _blobServiceClient)
        {
            songRepository = _songRepository;
            postRepository = _postRepository;
            blobServiceClient = _blobServiceClient;
        }

        public async Task<PostSong> CreatePostSongAsync(CreateSongModel model)
        {
            var post = await postRepository.Get(model.PostId);

            var unequeSongName = Guid.NewGuid().ToString() + "_" + model.SongFile.FileName.Replace(' ', '_');
            var unequePictureName = Guid.NewGuid().ToString() + "_" + model.SongImage.FileName.Replace(' ', '_');

            var blobSongContainerClient = blobServiceClient.GetBlobContainerClient("songs");
            var blobImageContainerClient = blobServiceClient.GetBlobContainerClient("images");

            var blobSongClient = blobSongContainerClient.GetBlobClient(unequeSongName);
            var blobImageClient = blobImageContainerClient.GetBlobClient(unequePictureName);

            using var songReader = model.SongFile.OpenReadStream();
            await blobSongClient.UploadAsync(songReader);

            using var imageReader = model.SongImage.OpenReadStream();
            await blobImageClient.UploadAsync(imageReader);

            var song = new PostSong { ImageUrl = blobImageClient.Uri.AbsoluteUri, Post = post, Source = blobSongClient.Uri.AbsoluteUri };

            post.PostSongs.Add(song);

            await songRepository.Add(song);

            return song;
        }

        public async Task Remove(int songId)
        {
            var song = await songRepository.Get(songId);

            await songRepository.Remove(song.Id);
        }
    }
}
