
using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface ISeatsService
    {
        public IEnumerable<Seats> GetSeats();
        public Seats GetSeat(int id);
        public int AddSeat(SeatsModel seat);
        public void UpdateSeat(Seats seat);
        public void DeleteSeat(int id);
    }
}
