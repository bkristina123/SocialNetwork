using SocialNetwork.Data.Models;
using SocialNetwork.Repositories.Interfaces;
using SocialNetwork.Services.Interfaces;
using System;

namespace SocialNetwork.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserService _userService;

        public CommentService(ICommentRepository commentRepository,
            IUserService userService)
        {
            _commentRepository = commentRepository;
            _userService = userService;

        }


        public void AddComment(string content, int postId)
        {
            var sessionUser = _userService.GetSessionUser();

            if(content is null)
            {
                return;
            }

            var comment = new Comment
            {
                Content = content,
                UserId = sessionUser.Id,
                DateCreated = DateTime.Now,
                PostId = postId
            };

            _commentRepository.AddComment(comment);
        }
    }
}
