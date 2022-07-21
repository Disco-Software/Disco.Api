using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Dto.Images;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class ImageService : IImageService
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly IMapper mapper;
        private readonly IPostRepository postRepository;
        private readonly IImageRepository imageRepository;



        public ImageService(
            BlobServiceClient _blobServiceClient,
            IMapper _mapper, 
            IPostRepository _postRepository,
            IImageRepository _imageRepository)
        {
            postRepository = _postRepository;
            imageRepository = _imageRepository;
            blobServiceClient = _blobServiceClient;
            mapper = _mapper;
        }


        public async Task<PostImage> CreatePostImage(CreateImageDto model)
        {
            var uniqueImageName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName.Replace(' ', '_');

            if (model.ImageFile == null)
                return null;

            if (model.ImageFile.Length == 0)
                return null;

            var containerClient = blobServiceClient.GetBlobContainerClient("images");
            var blobClient = containerClient.GetBlobClient(uniqueImageName);

            using var imageReader = model.ImageFile.OpenReadStream();
            var blobResult = blobClient.Upload(imageReader);

            var postImage = mapper.Map<PostImage>(model);
            postImage.Source = blobClient.Uri.AbsoluteUri;

            await imageRepository.AddAsync(postImage);

            return postImage;
        }

        public async Task RemoveImage(int id)
        {
           await imageRepository.Remove(id);
        }
    }
}
