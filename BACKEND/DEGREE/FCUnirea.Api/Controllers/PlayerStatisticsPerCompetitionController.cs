
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            return Ok(_statisticsService.GetPlayerStatisticsPerCompetitions());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var statistics = _statisticsService.GetPlayerStatisticPerCompetition(id);
            if (statistics != null)
            {
                return Ok(statistics);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] PlayerStatisticsPerCompetitionModel model)
        {
            return CreatedAtAction(null, _statisticsService.AddPlayerStatisticPerCompetition(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] PlayerStatisticsPerCompetition statistics)
        {
            _statisticsService.UpdatePlayerStatisticPerCompetition(statistics);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _statisticsService.DeletePlayerStatisticPerCompetition(id);
            return NoContent();
        }
    }
}
