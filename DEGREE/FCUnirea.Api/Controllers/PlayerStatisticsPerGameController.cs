using FCUnirea.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerStatisticsPerGameController : Controller
    {
        private readonly IPlayerStatisticsPerGameService _playerStatisticsPerGameService;

        public PlayerStatisticsPerGameController(IPlayerStatisticsPerGameService playerStatisticsPerGameService)
        {
            _playerStatisticsPerGameService = playerStatisticsPerGameService
;
        }
    }
}
