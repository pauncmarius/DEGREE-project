﻿
using FCUnirea.Business.Models;
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

        [HttpPost]
        public IActionResult Add([FromBody] TicketsModel model)
        {
            return CreatedAtAction(null, _ticketService.AddTicket(model));
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
    }
}
