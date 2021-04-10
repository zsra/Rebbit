using Rebbit.Core.Entities;
using Rebbit.Core.Interfaces;
using Rebbit.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rebbit.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly IAsyncRepository<Group> _groupRepository;
        private readonly IAppLogger<GroupService> _logger;

        public GroupService(IAsyncRepository<Group> groupRepository, IAppLogger<GroupService> logger)
        {
            _groupRepository = groupRepository;
            _logger = logger;
        }

        public async ValueTask<IEnumerable<Post>> GetNewestPosts(int groupId)
        {
            Group group = await _groupRepository.GetByIdAsync(groupId);
            return group.Posts.OrderByDescending(post => post.CreatedAt);
        }

        public async ValueTask<IEnumerable<Post>> GetPopularPosts(int groupId)
        {
            Group group = await _groupRepository.GetByIdAsync(groupId);
            return group.Posts.OrderByDescending(post => post.CreatedAt)
                .ThenByDescending(post => post.RatingInfo.GetRating());
        }

        public async ValueTask<IEnumerable<Post>> GetTopPostsByAllTime(int groupId)
        {
            Group group = await _groupRepository.GetByIdAsync(groupId);
            return group.Posts
                .OrderByDescending(post => post.RatingInfo.GetRating());
        }

        public async ValueTask<IEnumerable<Post>> GetTopPostsByDay(int groupId)
        {
            Group group = await _groupRepository.GetByIdAsync(groupId);
            return group.Posts.Where(post => post.CreatedAt >= DateTime.Now.AddDays(-1) )
                .OrderBy(post => post.RatingInfo.GetRating());
        }

        public async ValueTask<IEnumerable<Post>> GetTopPostsByMonth(int groupId)
        {
            Group group = await _groupRepository.GetByIdAsync(groupId);
            return group.Posts.Where(post => post.CreatedAt >= DateTime.Now.AddDays(-30))
                .OrderBy(post => post.RatingInfo.GetRating());
        }

        public async ValueTask<IEnumerable<Post>> GetTopPostsByWeek(int groupId)
        {
            Group group = await _groupRepository.GetByIdAsync(groupId);
            return group.Posts.Where(post => post.CreatedAt >= DateTime.Now.AddDays(-7))
                .OrderBy(post => post.RatingInfo.GetRating());
        }

        public async ValueTask<IEnumerable<Post>> GetTopPostsByYear(int groupId)
        {
            Group group = await _groupRepository.GetByIdAsync(groupId);
            return group.Posts.Where(post => post.CreatedAt >= DateTime.Now.AddDays(-365))
                .OrderBy(post => post.RatingInfo.GetRating());
        }
    }
}
