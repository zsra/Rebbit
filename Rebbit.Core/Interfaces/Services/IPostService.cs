using Rebbit.Core.Entities;
using System.Threading.Tasks;

namespace Rebbit.Core.Interfaces.Services
{
    public interface IPostService
    {
        ValueTask<Post> GetPostById(int postId);
        ValueTask<Post> Create(Post post);
        ValueTask<Post> Update(Post post);
        ValueTask DeleteById(int postId);
    }
}
