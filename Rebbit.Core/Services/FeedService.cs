using Rebbit.Core.Entities;
using Rebbit.Core.Interfaces;
using Rebbit.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rebbit.Core.Services
{
    public class FeedService : IFeedService
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IAppLogger<FeedService> _logger;

        private readonly IGroupService _groupService;

        public FeedService(IAsyncRepository<Post> postRepository, IAsyncRepository<User> userRepository,
            IAppLogger<FeedService> logger, IGroupService groupService)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _logger = logger;
            _groupService = groupService;
        }

        public async ValueTask<IEnumerable<Group>> GetFollowedGroups(int userId)
        {
            return (await _userRepository.GetByIdAsync(userId)).FollowedGroups;
        }

        public async ValueTask<IEnumerable<Post>> GetPersonalFeed(int userId)
        {
            List<Post> result = new List<Post>();
            IEnumerable<Group> groups = await GetFollowedGroups(userId);
            
            foreach (Group group in groups)
                result.AddRange(await _groupService.GetPopularPosts(group.Id));
            
            return result.OrderBy( p => p.RatingInfo?.GetRating() ); 
        }
    }
}
