//NewsController.cs
using System;
using System.Linq;
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



        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var news = _newsService.GetNewsItem(id);
            if (news == null)
                return NotFound("Știrea nu a fost găsită.");

            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
                return Unauthorized();

            var user = _usersService.GetByUsername(username);
            if (user == null)
                return Unauthorized();

            bool isAdmin = User.IsInRole("Admin");
            bool isAuthor = news.News_UsersId == user.Id;

            if (!isAdmin && !isAuthor)
                return Forbid("Nu ai dreptul să ștergi această știre.");

            _newsService.DeleteNews(id);
            return Ok(new { message = "Știrea a fost ștearsă." });
        }


    }
}
