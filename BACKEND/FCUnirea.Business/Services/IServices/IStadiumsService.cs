//IStadiumsService
using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface IStadiumsService
    {
        public IEnumerable<Stadiums> GetStadiums();
        public Stadiums GetStadium(int id);
        public int AddStadium(StadiumsModel stadium);
        public void UpdateStadium(Stadiums stadium);
        public void DeleteStadium(int id);
    }
}
