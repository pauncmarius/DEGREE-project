//playersController.cs
using System.Linq;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_playerService.GetPlayersWithTeamName());
        }


        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody] PlayersModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return CreatedAtAction(null, _playerService.AddPlayer(model));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] Players player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _playerService.UpdatePlayer(player);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _playerService.DeletePlayer(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet("byTeam/{teamId}")]
        public IActionResult GetByTeam(int teamId)
        {
            var players = _playerService.GetPlayersByTeam(teamId);
            if (players == null || !players.Any())
            {
                return NotFound("Nu există jucători pentru această echipă.");
            }
            return Ok(players);
        }

    }
}
