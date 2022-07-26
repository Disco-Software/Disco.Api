using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Images;
using Disco.Domain.Models;
using System;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class ImageService : IImageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IImageRepository _imageRepository;



        public ImageService(
            BlobServiceClient blobServiceClient,
            IMapper mapper, 
            IPostRepository postRepository,
            IImageRepository imageRepository)
        {
            _postRepository = postRepository;
            _imageRepository = imageRepository;
            _blobServiceClient = blobServiceClient;
            _mapper = mapper;
        }


        public async Task<PostImage> CreatePostImage(CreateImageDto model)
        {
            var uniqueImageName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName.Replace(' ', '_');

            if (model.ImageFile == null)
                return null;

            if (model.ImageFile.Length == 0)
                return null;

            var containerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blobClient = containerClient.GetBlobClient(uniqueImageName);

            using var imageReader = model.ImageFile.OpenReadStream();
            var blobResult = blobClient.Upload(imageReader);

            var postImage = _mapper.Map<PostImage>(model);
            postImage.Source = blobClient.Uri.AbsoluteUri;

            await _imageRepository.AddAsync(postImage);

            return postImage;
        }

        public async Task RemoveImage(int id)
        {
           await _imageRepository.Remove(id);
        }
    }
}
