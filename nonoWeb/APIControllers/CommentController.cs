using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nonoCore.Service;
using nonoCore.Entity;
using System.Collections.Generic;

namespace nonoWeb.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private CommentService _commentService = new CommentServiceEF();

        [HttpGet]
        public IEnumerable<Comment> GetComments()
        {
            return _commentService.GetComments();
        }

        [HttpPost]
        public void PostComment(Comment comment)
        {
            _commentService.AddComment(comment);
        }
    }
}
