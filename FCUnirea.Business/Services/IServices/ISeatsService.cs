using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface ISeatsService
    {
        IEnumerable<Seats> GetSeats();
        Seats GetSeat(int id);
        int AddSeat(SeatsModel seat);
        void UpdateSeat(Seats seat);
        void DeleteSeat(int id);
    }
}
