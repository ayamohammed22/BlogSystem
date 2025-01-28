using API_BlogSystem.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer_BlogSystem;
using System.Security.Claims;

namespace API_BlogSystem.Controllers
{
    public class CommentController : APIBaseController
    {
        private readonly CommentServices _commentServices;

        public CommentController(CommentServices commentServices) {
            _commentServices = commentServices;
        }

        [HttpPost("Create/{BlogId}")]
        [Authorize]
        public  async Task <IActionResult> CreateComment(int BlogId , CommentDTO _comment)
        {
            var Author_Email = User.FindFirstValue(ClaimTypes.Email);
            var comment = await _commentServices.CreateCommentAsync(Author_Email, _comment.Content, BlogId);
            return Ok(comment);
        }

        [HttpGet("{BlogId}")]
        public async Task<IActionResult> GetAllComments(int BlogId)
        {
            return Ok ( await _commentServices.GetCommentsAsync(BlogId));
        }

       

    }
}
