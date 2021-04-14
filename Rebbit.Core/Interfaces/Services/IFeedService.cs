using Rebbit.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rebbit.Core.Interfaces.Services
{
    public interface IFeedService
    {
        ValueTask<IEnumerable<Post>> GetPersonalFeed(int userId);
        ValueTask<IDictionary<int, string>> GetFollowedGroups(int userId);
    }
}
