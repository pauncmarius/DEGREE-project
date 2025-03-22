
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] UsersModel model)
        {
            return CreatedAtAction(null, _userService.AddUser(model));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Users user)
        {
            _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsersModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userId = _userService.RegisterUser(model);
                return Ok(new { message = "Utilizator înregistrat cu succes!", userId });
            }
            catch (Exception ex)
            {
                try
                {
                    var errorDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(ex.Message);
                    return BadRequest(errorDict);
                }
                catch
                {
                    return BadRequest(new { message = ex.Message });
                }
            }

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (string.IsNullOrEmpty(model.Username))
            {
                return BadRequest(new { message = "Trebuie să furnizați un username." });
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { message = "Parola este obligatorie." });
            }

            var token = _userService.Authenticate(model);

            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { message = "Credentialele sunt incorecte!" });

            return Ok(new { token });
        }

    }
}
