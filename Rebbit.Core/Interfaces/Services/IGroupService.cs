using Rebbit.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rebbit.Core.Interfaces.Services
{
    public interface IGroupService
    {
        ValueTask<IEnumerable<Post>> GetNewestPosts(int groupId);
        ValueTask<IEnumerable<Post>> GetPopularPosts(int groupId);
        ValueTask<IEnumerable<Post>> GetTopPostsByDay(int groupId);
        ValueTask<IEnumerable<Post>> GetTopPostsByWeek(int groupId);
        ValueTask<IEnumerable<Post>> GetTopPostsByMonth(int groupId);
        ValueTask<IEnumerable<Post>> GetTopPostsByYear(int groupId);
        ValueTask<IEnumerable<Post>> GetTopPostsByAllTime(int groupId);
    }
}
