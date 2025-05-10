//teamStatisticsController.cs
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamStatisticsController : Controller
    {
        private readonly ITeamStatisticsService _teamStatisticsService;

        public TeamStatisticsController(ITeamStatisticsService teamStatisticsService)
        {
            _teamStatisticsService = teamStatisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _teamStatisticsService.GetTeamStatisticsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teamStats = await _teamStatisticsService.GetTeamStatisticAsync(id);
            if (teamStats != null)
                return Ok(teamStats);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeamStatisticsModel model)
        {
            var newId = await _teamStatisticsService.AddTeamStatisticAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = newId }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TeamStatistics teamStats)
        {
            await _teamStatisticsService.UpdateTeamStatisticAsync(teamStats);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamStatisticsService.DeleteTeamStatisticAsync(id);
            return NoContent();
        }

        [HttpGet("byCompetition/{competitionId}")]
        public async Task<IActionResult> GetByCompetition(int competitionId)
        {
            var stats = await _teamStatisticsService.GetByCompetitionAsync(competitionId);
            return Ok(stats);
        }

        [HttpGet("standings/{competitionId}")]
        public async Task<IActionResult> GetStandingsByCompetition(int competitionId)
        {
            var standings = await _teamStatisticsService.GetStandingsByCompetitionAsync(competitionId);
            return Ok(standings);
        }

    }
}
