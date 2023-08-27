namespace Disco.Test.Business.Image.Services
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Azure.Storage.Blobs;
    using Disco.Business.Interfaces.Dtos.Images;
    using Disco.Business.Services.Mappers;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ImageServiceTests
    {
        private ImageService _testClass;
        private IMapper _mapper;

        private Mock<BlobServiceClient> _blobServiceClient;
        private Mock<IImageRepository> _imageRepository;

        [SetUp]
        public void SetUp()
        {
            _blobServiceClient = GetBlobServiceClientMock();
            
            _imageRepository = new Mock<IImageRepository>();

            _mapper = new MapperConfiguration(x => x.AddProfile(new PostMapProfile()))
                .CreateMapper();

            _testClass = new ImageService(_blobServiceClient.Object, _mapper, _imageRepository.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ImageService(_blobServiceClient.Object, _mapper, _imageRepository.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreatePostImage()
        {
            // Arrange
            var model = new CreateImageDto();

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            model.ImageFile = file;

            _imageRepository.Setup(mock => mock.AddAsync(It.IsAny<PostImage>())).Verifiable();

            // Act
            var result = await _testClass.CreatePostImage(model);

            // Assert
            _imageRepository.Verify(mock => mock.AddAsync(It.IsAny<PostImage>()));
        }

        [Test]
        public void CannotCallCreatePostImageWithNullModel()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreatePostImage(default));
        }

        [Test]
        public async Task CanCallRemoveImage()
        {
            // Arrange
            var id = 1981475678;

            _imageRepository.Setup(mock => mock.RemoveAsync(It.IsAny<PostImage>())).Verifiable();

            // Act
            await _testClass.RemoveImageAsync(id);

            // Assert
            _imageRepository.Verify(mock => mock.RemoveAsync(It.IsAny<PostImage>()));
        }

        private Mock<BlobServiceClient> GetBlobServiceClientMock()
        {
            var mock = new Mock<BlobServiceClient>();
            var mockBlobContainerClient = new Mock<BlobContainerClient>();
            var mockBlobClient = new Mock<BlobClient>();

            var uri = new Uri("https://blablabla.com");

            mockBlobContainerClient.Setup(i => i.AccountName)
                .Returns("Test account name");
            mock.Setup(x => x.GetBlobContainerClient(It.IsAny<string>()))
                .Returns(mockBlobContainerClient.Object);
            mockBlobContainerClient.Setup(x => x.GetBlobClient(It.IsAny<string>()))
                .Returns(mockBlobClient.Object);
            mockBlobClient.Setup(x => x.Uri)
                .Returns(uri);

            return mock;
        }
    }
}