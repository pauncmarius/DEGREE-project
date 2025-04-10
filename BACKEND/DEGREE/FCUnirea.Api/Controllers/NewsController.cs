
using System.Linq;
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
        private readonly ICommentsService _commentsService;


        public NewsController(INewsService newsService, ICommentsService commentsService)
        {
            _newsService = newsService;
            _commentsService = commentsService;
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
            if (news == null) return NotFound();

            var comments = _commentsService.GetByNewsId(id);

            return Ok(new
            {
                news.Id,
                news.Title,
                news.Text,
                news.CreatedAt,
                news.News_Users?.Username,
                Comments = comments.Select(c => new {
                    c.Text,
                    c.CreatedAt,
                    Username = c.Comment_User?.Username
                })
            });
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
