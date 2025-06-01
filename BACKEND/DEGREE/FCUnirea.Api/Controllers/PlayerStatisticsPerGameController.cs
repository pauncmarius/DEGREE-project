//playerstatisticspergamecontroller.cs
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
    public class PlayerStatisticsPerGameController : Controller
    {
        private readonly IPlayerStatisticsPerGameService _statisticsService;
        private readonly ITeamStatisticsService _teamStatisticsService;

        public PlayerStatisticsPerGameController(
            IPlayerStatisticsPerGameService statisticsService,
            ITeamStatisticsService teamStatisticsService)
        {
            _statisticsService = statisticsService;
            _teamStatisticsService = teamStatisticsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stats = await _statisticsService.GetPlayerStatisticsPerGamesAsync();
            if (stats == null || !stats.Any())
            {
                return NotFound("Nu au fost găsite statistici pentru jocuri.");
            }
            return Ok(stats);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var statistics = await _statisticsService.GetPlayerStatisticPerGameAsync(id);
            if (statistics == null)
            {
                return NotFound("Statisticile nu au fost găsite.");
            }
            return Ok(statistics);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PlayerStatisticsPerGameModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _statisticsService.AddAndUpdateGameScoreAsync(model);
            if (newId == 0)
            {
                return BadRequest("A apărut o eroare la adăugarea statisticilor.");
            }
            return CreatedAtAction(nameof(GetById), new { id = newId }, model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PlayerStatisticsPerGame statistics)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _statisticsService.UpdatePlayerStatisticPerGameAsync(statistics);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool wasGameAffected = await _statisticsService.DeletePlayerStatisticPerGameAsync(id);
            if (wasGameAffected)
            {
                await _teamStatisticsService.UpdateAllTeamStatisticsFromGamesAsync();
            }
            return NoContent();
        }

        [Authorize]
        [HttpGet("scorersByGame/{gameId}")]
        public async Task<IActionResult> GetScorersByGame(int gameId)
        {
            var result = await _statisticsService.GetScorersForGameAsync(gameId);
            if (result == null || !result.Any())
            {
                return NotFound("Nu au fost găsiți marcatori pentru acest joc.");
            }
            return Ok(result);
        }


    }
}
