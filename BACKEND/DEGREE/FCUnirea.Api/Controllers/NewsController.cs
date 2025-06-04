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

        public NewsController(INewsService newsService, IUsersService usersService)
        {
            _newsService = newsService;
            _usersService = usersService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_newsService.GetNews());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _newsService.GetNewsWithComments(id);
            if (result == null)
            {
                return NotFound("Știrea nu a fost găsită.");
            }
            return Ok(result);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody] NewsModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username)) return Unauthorized();

            var user = _usersService.GetByUsername(username);
            if (user == null) return BadRequest(new { message = "Utilizatorul nu există." });

            model.News_UsersId = user.Id;
            model.CreatedAt = DateTime.UtcNow;

            var id = _newsService.AddNews(model);
            if (id == 0)
                return BadRequest(new { message = "Știrea nu a fost adăugată." });

            return CreatedAtAction(null, id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] NewsModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _newsService.UpdateNews(model);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _newsService.DeleteNews(id);
            return NoContent();
        }
    }
}
