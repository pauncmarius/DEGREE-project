//seatController.cs
using System.Linq;
using System.Threading.Tasks;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_seatService.GetSeats());
        }

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

        [HttpPost]
        public IActionResult Add([FromBody] SeatsModel model)
        {
            return CreatedAtAction(null, _seatService.AddSeat(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Seats seat)
        {
            _seatService.UpdateSeat(seat);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _seatService.DeleteSeat(id);
            return NoContent();
        }

        [HttpGet("forGame/{gameId}")]
        public async Task<IActionResult> GetSeatsForGame(int gameId)
        {
            var result = await _seatService.GetSeatStatusForGameAsync(gameId);
            return Ok(result);
        }

    }
}
