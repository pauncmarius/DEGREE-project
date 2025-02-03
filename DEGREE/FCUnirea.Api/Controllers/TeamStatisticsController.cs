using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            return Ok(_teamStatisticsService.GetTeamStatistics());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teamStats = _teamStatisticsService.GetTeamStatistic(id);
            if (teamStats != null)
            {
                return Ok(teamStats);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] TeamStatisticsModel model)
        {
            return CreatedAtAction(null, _teamStatisticsService.AddTeamStatistic(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] TeamStatistics teamStats)
        {
            _teamStatisticsService.UpdateTeamStatistic(teamStats);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teamStatisticsService.DeleteTeamStatistic(id);
            return NoContent();
        }
    }
}
