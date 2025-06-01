//teamscontroller.cs
using System.Linq;
using System.Threading.Tasks;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_teamService.GetTeams());
        }

        [Authorize]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody] TeamsModel model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtAction(null, _teamService.AddTeam(model));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] Teams team)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _teamService.UpdateTeam(team);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teamService.DeleteTeam(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet("internal")]
        public async Task<IActionResult> GetInternalTeams()
        {
            var teams = await _teamService.GetInternalTeamsAsync();
            if (teams == null || !teams.Any())
            {
                return NotFound();
            }
            return Ok(teams);
        }
    }
}
