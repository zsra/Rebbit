using Rebbit.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rebbit.Core.Interfaces.Services
{
    public interface IFeedService
    {
        ValueTask<IEnumerable<Post>> GetPersonalFeed(int userId);
        ValueTask<IEnumerable<Group>> GetFollowedGroups(int userId);
    }
}
