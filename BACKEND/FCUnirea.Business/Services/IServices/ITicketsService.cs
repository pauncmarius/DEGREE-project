﻿//ITicketsService
using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface ITicketsService
    {
        public IEnumerable<Tickets> GetTickets();
        public Tickets GetTicket(int id);
        public void UpdateTicket(Tickets ticket);
        public void DeleteTicket(int id);

        Task<int> AddTicketAsync(TicketsModel ticket);

        Task<IEnumerable<TicketWithDetailsModel>> GetTicketsByUserIdAsync(int userId);
        Task<IEnumerable<TicketWithDetailsModel>> GetTicketsByGameIdAsync(int gameId);

    }
}
