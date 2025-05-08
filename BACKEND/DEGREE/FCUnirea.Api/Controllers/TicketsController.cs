
using System.Threading.Tasks;
using System;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ticketService.GetTickets());
        }

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

        [HttpPut]
        public IActionResult Update([FromBody] Tickets ticket)
        {
            _ticketService.UpdateTicket(ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ticketService.DeleteTicket(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TicketsModel model)
        {
            try
            {
                var id = await _ticketService.AddTicketAsync(model);
                return CreatedAtAction(nameof(GetById), new { id }, model);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet("byUser/{userId}")]
        public async Task<IActionResult> GetTicketsByUser(int userId)
        {
            var tickets = await _ticketService.GetTicketsByUserIdAsync(userId);
            return Ok(tickets);
        }


    }
}
