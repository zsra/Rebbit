using Rebbit.Core.Entities;
using Rebbit.Core.Interfaces;
using Rebbit.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Rebbit.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IAppLogger<PostService> _logger;

        public PostService(IAsyncRepository<Post> postRepository, IAppLogger<PostService> logger)
        {
            _postRepository = postRepository;
            _logger = logger;
        }

        public async ValueTask<Post> Create(Post post)
        {
            post.CreatedAt = DateTime.Now;
            return await _postRepository.AddAsync(post);
        }

        public async ValueTask DeleteById(int postId)
        {
            await _postRepository.DeleteAsync(postId);
        }

        public async ValueTask<Post> GetPostById(int postId)
        {
            return await _postRepository.GetByIdAsync(postId);
        }

        public async ValueTask<Post> Update(Post post)
        {
            switch (post.EditedInfo)
            {
                case null:
                    post.EditedInfo = new ValueObject.EditedInfo
                    {
                        DateOfLastEdit = DateTime.Now,
                        NumberOfEdit = 1
                    };
                    break;
                default:
                    post.EditedInfo.DateOfLastEdit = DateTime.Now;
                    post.EditedInfo.NumberOfEdit += 1;
                    break;
            }

            return await _postRepository.UpdateAsync(post);
        }
    }
}
