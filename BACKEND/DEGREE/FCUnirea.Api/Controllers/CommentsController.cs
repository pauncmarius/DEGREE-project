//CommetsController.cs
using FCUnirea.Business.Models;
using FCUnirea.Business.Services;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] CommentsModel model)
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username)) return Unauthorized();

            var commentId = _commentService.AddCommentWithUser(model, username);
            if (commentId == null)
                return BadRequest(new { message = "Utilizatorul nu există sau datele sunt invalide." });

            return Ok(new { message = "Comentariu adăugat cu succes!", commentId });
        }


        [HttpPut]
        public IActionResult Update([FromBody] Comments comment)
        {
            _commentService.UpdateComment(comment);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commentService.DeleteComment(id);
            return NoContent();
        }
    }
}
