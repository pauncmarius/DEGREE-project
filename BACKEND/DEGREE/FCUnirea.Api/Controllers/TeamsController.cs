
using System.Threading.Tasks;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        private readonly ITeamsService _teamService;

        public TeamsController(ITeamsService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_teamService.GetTeams());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var team = _teamService.GetTeam(id);
            if (team != null)
            {
                return Ok(team);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] TeamsModel model)
        {
            return CreatedAtAction(null, _teamService.AddTeam(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Teams team)
        {
            _teamService.UpdateTeam(team);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teamService.DeleteTeam(id);
            return NoContent();
        }

        [HttpGet("internal")]
        public async Task<IActionResult> GetInternalTeams()
        {
            var teams = await _teamService.GetInternalTeamsAsync();
            return Ok(teams);
        }
    }
}
