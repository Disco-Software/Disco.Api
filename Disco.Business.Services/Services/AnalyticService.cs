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
using Microsoft.Extensions.Hosting;
using Disco.Integration.Interfaces.Dtos.AudD;
using Disco.Business.Interfaces.Dtos.Analytic.Admin.GetAnalytics;
using Disco.Business.Utils.Guards;

namespace Disco.Business.Services.Services
{
    public class AnalyticService : IAnalyticService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public AnalyticService(
            IUserRepository userRepository, 
            IPostRepository postRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _mapper = mapper;

            DefaultGuard.ArgumentNull(_userRepository);
            DefaultGuard.ArgumentNull(_postRepository);
            DefaultGuard.ArgumentNull(_mapper);
        }

        public async Task<AnalyticResponseDto> GetAnalyticAsync(DateTime from, DateTime to, AnalyticFor statistics)
        {
            var users = await _userRepository.GetAllUsersAsync();
            var posts = await _postRepository.GetAllPostsAsync(from, to);
            var newUsers = await _userRepository.GetAllUsersAsync(from, to);

            var result = new AnalyticResponseDto();
            result.UsersCount = users.Count;
            result.PostsCount = posts.Count;
            result.NewUsersCount = newUsers.Count;

            (List<int>, List<int>, List<int>) periodAnalytics;

            switch (statistics)
            {
                case AnalyticFor.Day:
                    {
                        periodAnalytics = await GetPeriodAnalyticsAsync(from, to, x => x.AddHours(1));
                    }
                    break;
                case AnalyticFor.Week:
                    {
                        periodAnalytics = await GetPeriodAnalyticsAsync(from, to, x => x.AddDays(1));
                    }
                    break;
                case AnalyticFor.Month:
                    {
                        var periods = (to - from).TotalDays;

                        periodAnalytics = await GetPeriodAnalyticsAsync(from, to, x => x.AddDays(1));
                    }
                    break;
                case AnalyticFor.Year:
                    {
                        periodAnalytics = await GetPeriodAnalyticsAsync(from, to, x => x.AddMonths(1));
                    }
                    break;
                default:
                    {
                        periodAnalytics = await GetPeriodAnalyticsAsync(from, to, x => x.AddHours(1));
                    }
                    break;
            }

            result.AggregatedUsers = periodAnalytics.Item1;
            result.AggregatedNewUsers = periodAnalytics.Item2;
            result.AggregatedPosts = periodAnalytics.Item3;

            return result;
        }

        private async Task<(List<int>, List<int>, List<int>)> GetPeriodAnalyticsAsync(DateTime from, DateTime to, Func<DateTime, DateTime> addStep)
        {
            var users = new List<int>();
            var newUsers = new List<int>();
            var posts = new List<int>();

            var difference = to - from;
            var stepFrom = from;

            while (stepFrom < to)
            {
                var nextStep = addStep(stepFrom);

                var stepUsers = await _userRepository.GetAllUsersAsync(DateTime.MinValue, nextStep);
                var stepNewUsers = await _userRepository.GetAllUsersAsync(stepFrom, nextStep);
                var stepPosts = await _postRepository.GetAllPostsAsync(stepFrom, nextStep);

                users.Add(stepUsers.Count);
                posts.Add(stepPosts.Count);
                newUsers.Add(stepNewUsers.Count);

                stepFrom = nextStep;
            }

            return (users, newUsers, posts);
        }
    }
}
