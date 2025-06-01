//seatController.cs
using System.Linq;
using System.Threading.Tasks;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : Controller
    {
        private readonly ISeatsService _seatService;

        public SeatsController(ISeatsService seatService)
        {
            _seatService = seatService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_seatService.GetSeats());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var seat = _seatService.GetSeat(id);
            if (seat != null)
            {
                return Ok(seat);
            }

            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody] SeatsModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return CreatedAtAction(null, _seatService.AddSeat(model));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] Seats seat)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _seatService.UpdateSeat(seat);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _seatService.DeleteSeat(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet("forGame/{gameId}")]
        public async Task<IActionResult> GetSeatsForGame(int gameId)
        {
            var result = await _seatService.GetSeatStatusForGameAsync(gameId);
            if (result == null)
            {
                return NotFound("Nu au fost găsite locuri pentru acest joc.");
            }
            return Ok(result);
        }

    }
}
