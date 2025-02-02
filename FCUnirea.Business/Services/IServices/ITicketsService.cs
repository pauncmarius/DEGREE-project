using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface ITicketsService
    {
        IEnumerable<Tickets> GetTickets();
        Tickets GetTicket(int id);
        int AddTicket(Tickets ticket);
        void UpdateTicket(Tickets ticket);
        void DeleteTicket(int id);
    }
}
