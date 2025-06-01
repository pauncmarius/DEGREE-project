//CompetitionsController.cs
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsController : ControllerBase
    {
        private readonly ICompetitionsService _competitionService;

        public CompetitionsController(ICompetitionsService competitionService)
        {
            _competitionService = competitionService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll() => Ok(_competitionService.GetCompetitions());

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var competition = _competitionService.GetCompetition(id);
            if (competition != null)
            {
                return Ok(competition);
            }

            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody] CompetitionsModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtAction(null, _competitionService.AddCompetition(model));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] Competitions competition)
        {
            _competitionService.UpdateCompetition(competition);
            return NoContent();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           _competitionService.DeleteCompetition(id);
            return NoContent();
        }

    }
}
