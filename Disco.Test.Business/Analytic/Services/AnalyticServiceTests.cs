namespace Disco.Test.Business.Analytic.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.Business.Interfaces.Enums;
    using Disco.Business.Services.Mapper;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AnalyticServiceTests
    {
        private AnalyticService _testClass;
        private Mock<IUserRepository> _userRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _userRepository = new Mock<IUserRepository>();
            _postRepository = new Mock<IPostRepository>();
            _mapper = new Mock<IMapper>();
            _testClass = new AnalyticService(_userRepository.Object, _postRepository.Object, _mapper.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AnalyticService(_userRepository.Object, _postRepository.Object, _mapper.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallGetAllStatisticsAsync()
        {
            // Arrange
            var @from = DateTime.UtcNow;
            var to = DateTime.UtcNow;
            var statistics = AnalyticFor.Year;

            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile(new StatisticsMapProfile());
            }).CreateMapper();

            _userRepository.Setup(mock => mock.GetAllUsersAsync()).ReturnsAsync(new List<User>());
            _userRepository.Setup(mock => mock.GetAllUsersAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(new List<User>());
            _postRepository.Setup(mock => mock.GetAllPostsAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(new List<Post>());

            _testClass = new AnalyticService(_userRepository.Object, _postRepository.Object, mapper);

            // Act
            var result = await _testClass.GetAnalyticAsync(from, to, statistics);

            // Assert
            _userRepository.Verify(mock => mock.GetAllUsersAsync());
            _userRepository.Verify(mock => mock.GetAllUsersAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>()));
            _postRepository.Verify(mock => mock.GetAllPostsAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>()));
        }
    }
}