using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface ITeamsService
    {
        public IEnumerable<Teams> GetTeams();
        public Teams GetTeam(int id);
        public int AddTeam(TeamsModel team);
        public void UpdateTeam(Teams team);
        public void DeleteTeam(int id);
    }
}
