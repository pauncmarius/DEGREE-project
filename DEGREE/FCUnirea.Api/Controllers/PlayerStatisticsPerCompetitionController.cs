using FCUnirea.Business.Services;
using FCUnirea.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerStatisticsPerCompetitionController : Controller
    {
        private readonly IPlayerStatisticsPerCompetitionService _playerStatisticsPerCompetitionService;

        public PlayerStatisticsPerCompetitionController(IPlayerStatisticsPerCompetitionService playerStatisticsPerCompetitionService)
        {
            _playerStatisticsPerCompetitionService = playerStatisticsPerCompetitionService;
        }
    }
}
