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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentService = commentsService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll() => Ok(_commentService.GetComments());

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var comment = _commentService.GetComment(id);
            if (comment == null)
                return NotFound(new { message = "Comentariul nu a fost găsit." });

            return Ok(comment);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] CommentsModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
                return BadRequest(new { message = "Utilizatorul nu este autentificat." });

            var commentId = _commentService.AddCommentWithUser(model, username);
            if (commentId == null)
                return BadRequest(new { message = "Utilizatorul nu există sau datele sunt invalide." });

            return Ok(new { message = "Comentariu adăugat cu succes!", commentId });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] Comments comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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

