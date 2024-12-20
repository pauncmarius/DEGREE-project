using FCUnirea.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : Controller
    {
        private readonly ISeatsService _seatsService;

        public SeatsController(ISeatsService seatsService)
        {
            _seatsService = seatsService;
        }
    }
}
