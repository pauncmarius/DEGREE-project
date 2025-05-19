//NewsController.cs
using System;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IUsersService _usersService;
        private readonly ICommentsService _commentsService;


        public NewsController(INewsService newsService, ICommentsService commentsService, IUsersService usersService)
        {
            _newsService = newsService;
            _commentsService = commentsService;
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_newsService.GetNews());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _newsService.GetNewsWithComments(id);
            return result == null ? NotFound() : Ok(result);
        }



        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] NewsModel model)
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username)) return Unauthorized();

            var user = _usersService.GetByUsername(username);
            if (user == null) return BadRequest(new { message = "Utilizatorul nu există." });

            model.News_UsersId = user.Id;
            model.CreatedAt = DateTime.UtcNow;

            var id = _newsService.AddNews(model);
            return CreatedAtAction(null, id);
        }


        [HttpPut]
        public IActionResult Update([FromBody] NewsModel model)
        {
            _newsService.UpdateNews(model);
            return NoContent();
        }



        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var news = _newsService.GetNewsItem(id);
            if (news == null)
                return NotFound("Știrea nu a fost găsită.");

            _newsService.DeleteNews(id);
            return Ok(new { message = "Știrea a fost ștearsă." });
        }


    }
}
