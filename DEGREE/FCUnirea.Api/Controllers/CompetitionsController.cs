using FCUnirea.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsController : Controller
    {
        private readonly ICompetitionsService _competitionsService;

        public CompetitionsController(ICompetitionsService competitionsService)
        {
            _competitionsService = competitionsService;
        }
    }
}
