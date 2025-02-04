using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface ICompetitionsService
    {
        public IEnumerable<Competitions> GetCompetitions();
        public Competitions GetCompetition(int id);
        public int AddCompetition(CompetitionsModel competition);
        public void UpdateCompetition(Competitions competition);
        public void DeleteCompetition(int id);
    }
}
