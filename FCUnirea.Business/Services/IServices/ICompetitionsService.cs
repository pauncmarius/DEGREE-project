using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface ICompetitionsService
    {
        IEnumerable<Competitions> GetCompetitions();
        Competitions GetCompetition(int id);
        int AddCompetition(CompetitionsModel competition);
        void UpdateCompetition(Competitions competition);
        void DeleteCompetition(int id);
    }
}
