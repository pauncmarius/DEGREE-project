using System.Threading.Tasks;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stats = await _statisticsService.GetPlayerStatisticsPerGamesAsync();
            return Ok(stats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var statistics = await _statisticsService.GetPlayerStatisticPerGameAsync(id);
            return statistics != null ? Ok(statistics) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PlayerStatisticsPerGameModel model)
        {
            var newId = await _statisticsService.AddAndUpdateGameScoreAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = newId }, model);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PlayerStatisticsPerGame statistics)
        {
            await _statisticsService.UpdatePlayerStatisticPerGameAsync(statistics);
            return NoContent();
        }

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
    }
}
