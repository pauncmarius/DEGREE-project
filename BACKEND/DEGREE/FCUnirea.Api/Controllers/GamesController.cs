//GamesController.cs
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
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gameService;

        public GamesController(IGamesService gameService)
        {
            _gameService = gameService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_gameService.GetGames());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var game = _gameService.GetGame(id);
            if (game != null)
            {
                return Ok(game);
            }

            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody] GamesModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return CreatedAtAction(null, _gameService.AddGame(model));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] Games game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _gameService.UpdateGame(game);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _gameService.DeleteGame(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet("byTeam/{teamId}")]
        public IActionResult GetGamesByTeam(int teamId)//
        {
            var games = _gameService.GetGamesWithTeamNamesByTeam(teamId);
            if (games == null || !games.Any())
            {
                return NotFound();
            }
            return Ok(games);
        }

        [Authorize]
        [HttpGet("home-upcoming")]
        public IActionResult GetHomeUpcomingGames()
        {
            var games = _gameService.GetHomeUpcomingGames();
            if (games == null || !games.Any())
            {
                return NotFound();
            }
            return Ok(games);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("withNames")]
        public IActionResult GetAllWithNames()
        {
            var games = _gameService.GetAllGamesWithNames();
            if (games == null || !games.Any())
            {
                return NotFound();
            }
            return Ok(games);
        }

        [Authorize]
        [HttpGet("byCompetition/{competitionId}")]
        public IActionResult GetGamesByCompetition(int competitionId)
        {

            var games = _gameService.GetGamesWithTeamNamesByCompetition(competitionId);
            if (games == null || !games.Any())
            {
                return NotFound();
            }
            return Ok(games);
        }

    }
}
