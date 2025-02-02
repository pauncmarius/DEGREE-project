﻿using AutoMapper;
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
    public class CompetitionsService : ICompetitionsService
    {
        private readonly ICompetitionsRepository _competitionRepository;
        private readonly IMapper _mapper;

        public CompetitionsService(ICompetitionsRepository competitionRepository, IMapper mapper)
        {
            _competitionRepository = competitionRepository;
            _mapper = mapper;
        }

        public IEnumerable<Competitions> GetCompetitions() => _competitionRepository.ListAll();
        public Competitions GetCompetition(int id) => _competitionRepository.GetById(id);
        public int AddCompetition(Competitions competition) => _competitionRepository.Add(competition).Id;
        public void UpdateCompetition(Competitions competition) => _competitionRepository.Update(competition);
        public void DeleteCompetition(int id)
        {
            var competition = _competitionRepository.GetById(id);
            if (competition != null) _competitionRepository.Delete(competition);
        }
    }
}
