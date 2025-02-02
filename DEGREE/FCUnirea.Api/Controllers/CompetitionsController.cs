using FCUnirea.Business.Services;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsController : Controller
    {
        private readonly ICompetitionsService _competitionService;

        public CompetitionsController(ICompetitionsService competitionService)
        {
            _competitionService = competitionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_competitionService.GetCompetitions());
        }

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

        [HttpPost]
        public IActionResult Add([FromBody] AddCompetitionModel model)
        {
            return CreatedAtAction(null, _competitionService.AddCompetition(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Competitions competition)
        {
            _competitionService.UpdateCompetition(competition);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _competitionService.DeleteCompetition(id);
            return NoContent();
        }
    }
}
