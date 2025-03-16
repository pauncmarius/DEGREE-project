
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System.Collections.Generic;

namespace FCUnirea.Business.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly ITicketsRepository _repository;
        private readonly IMapper _mapper;

        public TicketsService(ITicketsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<Tickets> GetTickets() => _repository.ListAll();
        public Tickets GetTicket(int id) => _repository.GetById(id);
        public int AddTicket(TicketsModel ticket) => _repository.Add(_mapper.Map<Tickets>(ticket)).Id;
        public void UpdateTicket(Tickets ticket) => _repository.Update(ticket);
        public void DeleteTicket(int id)
        {
            var ticket = _repository.GetById(id);
            if (ticket != null) _repository.Delete(ticket);
        }
    }
}
