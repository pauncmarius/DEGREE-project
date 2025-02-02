using AutoMapper;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamsService(ITeamsRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public IEnumerable<Teams> GetTeams() => _teamRepository.ListAll();
        public Teams GetTeam(int id) => _teamRepository.GetById(id);
        public int AddTeam(Teams team) => _teamRepository.Add(team).Id;
        public void UpdateTeam(Teams team) => _teamRepository.Update(team);
        public void DeleteTeam(int id)
        {
            var team = _teamRepository.GetById(id);
            if (team != null) _teamRepository.Delete(team);
        }
    }
}
