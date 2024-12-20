using FCUnirea.Business.Services.IServices;
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
    }
}
