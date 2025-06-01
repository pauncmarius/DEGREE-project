//playerstatisticspercompetitioncontroller.cs
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerStatisticsPerCompetitionController : Controller
    {
        private readonly IPlayerStatisticsPerCompetitionService _statisticsService;

        public PlayerStatisticsPerCompetitionController(IPlayerStatisticsPerCompetitionService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [Authorize] 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _statisticsService.GetPlayerStatisticsPerCompetitionsAsync());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var statistics = await _statisticsService.GetPlayerStatisticPerCompetitionAsync(id);

            if (statistics != null)
            {
                return Ok(statistics);
            }
            return NotFound("Statisticile nu au fost găsite.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PlayerStatisticsPerCompetitionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _statisticsService.AddPlayerStatisticPerCompetitionAsync(model);
            if (newId == 0)
            {
                return BadRequest("A apărut o eroare la adăugarea statisticilor.");
            }
            return CreatedAtAction(nameof(GetById), new { id = newId }, model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PlayerStatisticsPerCompetition statistics)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _statisticsService.UpdatePlayerStatisticPerCompetitionAsync(statistics);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _statisticsService.DeletePlayerStatisticPerCompetitionAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet("scorers/{competitionId}")]
        public async Task<IActionResult> GetTopScorers(int competitionId)
        {
            var scorers = await _statisticsService.GetTopScorersByCompetitionAsync(competitionId);
            if (scorers == null || !scorers.Any())
            {
                return NotFound("Nu au fost găsiți marcatori pentru competiția specificată.");
            }
            return Ok(scorers);
        }

    }
}
