//usersController.cs
using System.Collections.Generic;
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersService _userService;
        private readonly IMapper _mapper;


        public UsersController(IUsersService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
        public IActionResult Register([FromBody] UsersModel model)
        {
            Dictionary<string, string> errors;
            var userId = _userService.RegisterUser(model, out errors);

            if (userId == null)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Datele introduse nu sunt valide.",
                    errors // aici e Dictionary-ul complet
                });
            }

            return Ok(new
            {
                success = true,
                message = "Utilizator înregistrat cu succes!",
                userId
            });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = _userService.Authenticate(model);

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { error = "Credentialele sunt incorecte!" });

            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("my-profile")]
        public IActionResult GetCurrentUser()
        {
            var username = User.Identity?.Name;

            if (string.IsNullOrEmpty(username))
                return Unauthorized();

            var user = _userService.GetByUsername(username);
            if (user == null) return NotFound();

            var profile = _mapper.Map<UsersModel>(user);
            return Ok(profile);
        }

        [Authorize]
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            var username = User.Identity?.Name;

            if (!_userService.ChangePassword(username, model.CurrentPassword, model.NewPassword))
                return BadRequest(new { message = "Parola curentă este greșită." });

            return Ok(new { message = "Parola a fost schimbată cu succes." });
        }

        [Authorize]
        [HttpPost("update-name")]
        public IActionResult UpdateName([FromBody] NameUpdateModel model)
        {
            var username = User.Identity?.Name;
            _userService.UpdateName(username, model.FirstName, model.LastName);
            return Ok();
        }

        [Authorize]
        [HttpPost("update-username")]
        public IActionResult UpdateUsername([FromBody] UsernameUpdateModel model)
        {
            var username = User.Identity?.Name;
            if (!_userService.UpdateUsername(username, model.Username, out string error))
                return BadRequest(new { message = error });

            return Ok();
        }

        [Authorize]
        [HttpPost("update-email")]
        public IActionResult UpdateEmail([FromBody] EmailUpdateModel model)
        {
            var username = User.Identity?.Name;
            if (!_userService.UpdateEmail(username, model.Email, out string error))
                return BadRequest(new { message = error });

            return Ok();
        }

        [Authorize]
        [HttpPost("update-phone")]
        public IActionResult UpdatePhone([FromBody] PhoneUpdateModel model)
        {
            var username = User.Identity?.Name;
            if (!_userService.UpdatePhone(username, model.PhoneNumber, out string error))
                return BadRequest(new { message = error });

            return Ok();
        }

        [Authorize]
        [HttpDelete("delete-account")]
        public IActionResult DeleteAccount()
        {
            var username = User.Identity?.Name;
            var user = _userService.GetByUsername(username);

            if (user == null)
                return NotFound();

            _userService.DeleteUser(user.Id);
            return Ok(new { message = "Contul a fost șters." });
        }

    }
}
