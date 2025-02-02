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
        public int AddTicket(Tickets ticket) => _repository.Add(ticket).Id;
        public void UpdateTicket(Tickets ticket) => _repository.Update(ticket);
        public void DeleteTicket(int id)
        {
            var ticket = _repository.GetById(id);
            if (ticket != null) _repository.Delete(ticket);
        }
    }
}
