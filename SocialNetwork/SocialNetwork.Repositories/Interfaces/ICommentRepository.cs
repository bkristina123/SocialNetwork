using SocialNetwork.Data.Models;

namespace SocialNetwork.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        void AddComment(Comment comment);
    }
}
