//NewsController.cs
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
            var result = _newsService.GetNewsWithComments(id);
            return result == null ? NotFound() : Ok(result);
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
