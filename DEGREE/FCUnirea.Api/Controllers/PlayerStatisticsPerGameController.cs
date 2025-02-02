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

        public PlayerStatisticsPerGameController(IPlayerStatisticsPerGameService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_statisticsService.GetPlayerStatisticsPerGames());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var statistics = _statisticsService.GetPlayerStatisticPerGame(id);
            if (statistics != null)
            {
                return Ok(statistics);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddPlayerStatisticsModel model)
        {
            return CreatedAtAction(null, _statisticsService.AddPlayerStatisticPerGame(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] PlayerStatisticsPerGame statistics)
        {
            _statisticsService.UpdatePlayerStatisticPerGame(statistics);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _statisticsService.DeletePlayerStatisticPerGame(id);
            return NoContent();
        }
    }
}
