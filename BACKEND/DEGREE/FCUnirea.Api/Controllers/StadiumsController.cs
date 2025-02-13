using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumsController : Controller
    {
        private readonly IStadiumsService _stadiumService;

        public StadiumsController(IStadiumsService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_stadiumService.GetStadiums());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var stadium = _stadiumService.GetStadium(id);
            if (stadium != null)
            {
                return Ok(stadium);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] StadiumsModel model)
        {
            return CreatedAtAction(null, _stadiumService.AddStadium(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Stadiums stadium)
        {
            _stadiumService.UpdateStadium(stadium);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _stadiumService.DeleteStadium(id);
            return NoContent();
        }
    }
}
