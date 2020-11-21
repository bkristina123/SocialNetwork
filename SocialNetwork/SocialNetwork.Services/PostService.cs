using SocialNetwork.Repositories.Interfaces;
using SocialNetwork.Services.Interfaces;

namespace SocialNetwork.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
    }
}
