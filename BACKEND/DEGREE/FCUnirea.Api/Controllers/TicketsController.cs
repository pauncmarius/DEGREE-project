//ticketController.cs
using System.Threading.Tasks;
using System;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace FCUnirea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : Controller
    {
        private readonly ITicketsService _ticketService;

        public TicketsController(ITicketsService ticketService)
        {
            _ticketService = ticketService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ticketService.GetTickets());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ticket = _ticketService.GetTicket(id);
            if (ticket != null)
            {
                return Ok(ticket);
            }

            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] Tickets ticket)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ticketService.UpdateTicket(ticket);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ticketService.DeleteTicket(id);
            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TicketsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var id = await _ticketService.AddTicketAsync(model);
                if (id == 0)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(GetById), new { id }, model);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("byUser/{userId}")]
        public async Task<IActionResult> GetTicketsByUser(int userId)
        {
            var tickets = await _ticketService.GetTicketsByUserIdAsync(userId);
            if (tickets == null || !tickets.Any())
            {
                return NotFound();
            }
            return Ok(tickets);
        }


    }
}
