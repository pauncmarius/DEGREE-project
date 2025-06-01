//teamStatisticsController.cs
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _teamStatisticsService.GetTeamStatisticsAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teamStats = await _teamStatisticsService.GetTeamStatisticAsync(id);
            if (teamStats != null)
                return Ok(teamStats);

            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeamStatisticsModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _teamStatisticsService.AddTeamStatisticAsync(model);
            if (newId == 0)
                return BadRequest();

            return CreatedAtAction(nameof(GetById), new { id = newId }, model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TeamStatistics teamStats)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _teamStatisticsService.UpdateTeamStatisticAsync(teamStats);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamStatisticsService.DeleteTeamStatisticAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet("standings/{competitionId}")]
        public async Task<IActionResult> GetStandingsByCompetition(int competitionId)
        {
            var standings = await _teamStatisticsService.GetStandingsByCompetitionAsync(competitionId);
            if (standings == null)
                return NotFound();
            return Ok(standings);
        }
    }
}
