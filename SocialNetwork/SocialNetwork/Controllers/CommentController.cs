using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Services.Interfaces;

namespace SocialNetwork.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost]
        public IActionResult AddComment(string content, int postId)
        {
            _commentService.AddComment(content, postId);
            return RedirectToAction("Overview", "Post", new { postId = postId});
        }
    }
}