using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _statisticsService.GetPlayerStatisticsPerCompetitionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var statistics = await _statisticsService.GetPlayerStatisticPerCompetitionAsync(id);
            return statistics != null ? Ok(statistics) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PlayerStatisticsPerCompetitionModel model)
        {
            var newId = await _statisticsService.AddPlayerStatisticPerCompetitionAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = newId }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PlayerStatisticsPerCompetition statistics)
        {
            await _statisticsService.UpdatePlayerStatisticPerCompetitionAsync(statistics);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _statisticsService.DeletePlayerStatisticPerCompetitionAsync(id);
            return NoContent();
        }
    }
}
