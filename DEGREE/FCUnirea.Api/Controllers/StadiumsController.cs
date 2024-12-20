using FCUnirea.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumsController : Controller
    {
        private readonly IStadiumsService _stadiumsService;

        public StadiumsController(IStadiumsService stadiumsService)
        {
            _stadiumsService = stadiumsService;
        }
    }
}
