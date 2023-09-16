using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterApp.Dto.CommentD;
using TwitterApp.Service.ServiceInterface;

namespace TwitterApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<CommentDto>>> CreateComment(int tweetId,CommentDto comment)
        {
            var result = await _commentService.CreateComment(comment,tweetId);  
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _commentService.DeleteComment(id);
            return result == false ? NotFound() : Ok(result);
        }



    }
}
