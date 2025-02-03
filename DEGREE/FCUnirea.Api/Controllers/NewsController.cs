using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_newsService.GetNews());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var news = _newsService.GetNewsItem(id);
            if (news != null)
            {
                return Ok(news);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] NewsModel model)
        {
            return CreatedAtAction(null, _newsService.AddNews(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] News news)
        {
            _newsService.UpdateNews(news);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _newsService.DeleteNews(id);
            return NoContent();
        }
    }
}
