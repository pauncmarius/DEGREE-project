using FCUnirea.Business.Models;
using FCUnirea.Business.Services;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : Controller
    {
        private readonly IFeedbacksService _feedbackService;

        public FeedbacksController(IFeedbacksService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_feedbackService.GetFeedbacks());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var feedback = _feedbackService.GetFeedback(id);
            if (feedback != null)
            {
                return Ok(feedback);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] FeedbacksModel model)
        {
            return CreatedAtAction(null, _feedbackService.AddFeedback(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Feedbacks feedback)
        {
            _feedbackService.UpdateFeedback(feedback);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _feedbackService.DeleteFeedback(id);
            return NoContent();
        }
    }
}
