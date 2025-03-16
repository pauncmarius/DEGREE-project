
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System.Collections.Generic;

namespace FCUnirea.Business.Services
{
    public class StadiumsService : IStadiumsService
    {
        private readonly IStadiumsRepository _stadiumRepository;
        private readonly IMapper _mapper;

        public StadiumsService(IStadiumsRepository stadiumRepository, IMapper mapper)
        {
            _stadiumRepository = stadiumRepository;
            _mapper = mapper;
        }

        public IEnumerable<Stadiums> GetStadiums() => _stadiumRepository.ListAll();
        public Stadiums GetStadium(int id) => _stadiumRepository.GetById(id);
        public int AddStadium(StadiumsModel stadium) => _stadiumRepository.Add(_mapper.Map<Stadiums>(stadium)).Id;
        public void UpdateStadium(Stadiums stadium) => _stadiumRepository.Update(stadium);
        public void DeleteStadium(int id)
        {
            var stadium = _stadiumRepository.GetById(id);
            if (stadium != null) _stadiumRepository.Delete(stadium);
        }
    }
}
