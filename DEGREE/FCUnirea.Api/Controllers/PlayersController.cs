using FCUnirea.Business.Services;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : Controller
    {
        private readonly IPlayersService _playerService;

        public PlayersController(IPlayersService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_playerService.GetPlayers());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var player = _playerService.GetPlayer(id);
            if (player != null)
            {
                return Ok(player);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddPlayerModel model)
        {
            return CreatedAtAction(null, _playerService.AddPlayer(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Players player)
        {
            _playerService.UpdatePlayer(player);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _playerService.DeletePlayer(id);
            return NoContent();
        }
    }
}
