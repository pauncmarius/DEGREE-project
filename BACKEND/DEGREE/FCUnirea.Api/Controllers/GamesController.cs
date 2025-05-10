//GamesController.cs
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : Controller
    {
        private readonly IGamesService _gameService;

        public GamesController(IGamesService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_gameService.GetGames());
        }

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

        [HttpPost]
        public IActionResult Add([FromBody] GamesModel model)
        {
            return CreatedAtAction(null, _gameService.AddGame(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Games game)
        {
            _gameService.UpdateGame(game);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _gameService.DeleteGame(id);
            return NoContent();
        }

        [HttpGet("byTeam/{teamId}")]
        public IActionResult GetGamesByTeam(int teamId)
        {
            var games = _gameService.GetGamesWithTeamNamesByTeam(teamId);
            return Ok(games);
        }

        [HttpGet("home-upcoming")]
        public IActionResult GetHomeUpcomingGames()
        {
            var games = _gameService.GetHomeUpcomingGames();
            return Ok(games);
        }

    }
}
