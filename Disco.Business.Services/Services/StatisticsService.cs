using Disco.Business.Interfaces.Dtos.Statistics;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Disco.Domain.Models.Models;
using AutoMapper;
using Disco.Business.Interfaces.Enums;

namespace Disco.Business.Services.Services
{
    public class StatisticsService : IAnalyticService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public StatisticsService(
            IUserRepository userRepository, 
            IPostRepository postRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<AnalyticDto> GetAllStatisticsAsync(DateTime from, DateTime to, AnalyticFor statistics)
        {
            var users = await _userRepository.GetAllUsersAsync();
            var posts = new List<Post>();
            var newUsers = new List<User>();

            switch (statistics)
            {
                case AnalyticFor.Day:
                    {
                        from = DateTime.UtcNow.AddDays(-1);
                        to = DateTime.UtcNow;

                        posts = await _postRepository.GetAllPostsAsync(from, to);
                        newUsers = await _userRepository.GetAllUsersAsync(from, to);
                    }
                    break;
                case AnalyticFor.Week:
                    {
                        from = DateTime.UtcNow.AddDays(-7);
                        to = DateTime.UtcNow;

                        posts = await _postRepository.GetAllPostsAsync(from, to);
                        newUsers = await _userRepository.GetAllUsersAsync(from, to);
                    }
                    break;
                case AnalyticFor.Month:
                    {
                        var days = DateTime.DaysInMonth(from.Year, from.Month);
                        from = DateTime.UtcNow.AddDays(-days);
                        to = DateTime.UtcNow;

                        posts = await _postRepository.GetAllPostsAsync(from, to);
                        newUsers = await _userRepository.GetAllUsersAsync(from, to);
                    }
                    break;
                case AnalyticFor.Year:
                    {
                        from = DateTime.UtcNow.AddYears(-1);
                        to = DateTime.UtcNow;

                        posts = await _postRepository.GetAllPostsAsync(from, to);
                        newUsers = await _userRepository.GetAllUsersAsync(from, to);
                    }
                    break;
                default:
                    {
                        var days = DateTime.DaysInMonth(from.Year, from.Month);
                        from = DateTime.UtcNow.AddDays(-days);
                        to = DateTime.UtcNow;

                        posts = await _postRepository.GetAllPostsAsync(from, to);
                        newUsers = await _userRepository.GetAllUsersAsync(from, to);
                    }
                    break;
            }

            var statisticsDto = _mapper.Map<AnalyticDto>(users);
            statisticsDto.Posts = posts;
            statisticsDto.RegisteredUsers = newUsers;
            statisticsDto.PostsCount = posts.Count;
            statisticsDto.NewUsersCount = newUsers.Count;
            statisticsDto.UsersCount = users.Count;

            return statisticsDto;
        }
    }
}
