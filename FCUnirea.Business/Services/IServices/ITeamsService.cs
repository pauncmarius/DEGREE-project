using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface ITeamsService
    {
        IEnumerable<Teams> GetTeams();
        Teams GetTeam(int id);
        int AddTeam(TeamsModel team);
        void UpdateTeam(Teams team);
        void DeleteTeam(int id);
    }
}
