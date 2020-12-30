namespace SocialNetwork.Services.Interfaces
{
    public interface ICommentService
    {
        void AddComment(string content, int postId);
    }
}
