
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentService = commentsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_commentService.GetComments());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var comment = _commentService.GetComment(id);
            if (comment != null)
            {
                return Ok(comment);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] CommentsModel model)
        {
            return CreatedAtAction(null, _commentService.AddComment(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Comments comment)
        {
            _commentService.UpdateComment(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commentService.DeleteComment(id);
            return NoContent();
        }
    }
}
