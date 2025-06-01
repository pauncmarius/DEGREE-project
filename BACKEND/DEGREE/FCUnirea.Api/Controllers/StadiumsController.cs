//stadiumsController.cs
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_stadiumService.GetStadiums());
        }

        [Authorize]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody] StadiumsModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return CreatedAtAction(null, _stadiumService.AddStadium(model));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] Stadiums stadium)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _stadiumService.UpdateStadium(stadium);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _stadiumService.DeleteStadium(id);
            return NoContent();
        }
    }
}
