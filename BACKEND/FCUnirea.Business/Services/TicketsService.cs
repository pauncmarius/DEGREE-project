
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly ITicketsRepository _repository;
        private readonly IGamesRepository _gamesRepository;

        private readonly IMapper _mapper;

        public TicketsService(ITicketsRepository repository, IMapper mapper, IGamesRepository gamesRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _gamesRepository = gamesRepository;
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

        public async Task<int> AddTicketAsync(TicketsModel model)
        {
            var ticket = _mapper.Map<Tickets>(model);

            // 1. Verifică dacă locul este deja rezervat pentru acel meci
            var existingTickets = await _repository.ListAllAsync();
            bool isTaken = existingTickets.Any(t =>
                t.Ticket_GamesId == ticket.Ticket_GamesId &&
                t.Ticket_SeatsId == ticket.Ticket_SeatsId);

            if (isTaken)
                throw new InvalidOperationException("Locul este deja rezervat pentru acest meci.");

            // 2. Verifică dacă stadionul este intern (ID 1, 11 sau 21)
            var game = await _gamesRepository.GetByIdAsync(ticket.Ticket_GamesId.Value);
            if (game == null || !(new[] { 1, 11, 21 }.Contains(game.Game_StadiumsId ?? -1)))
            {
                throw new InvalidOperationException("Rezervările sunt permise doar pentru stadioanele interne.");
            }

            // 3. Salvează biletul
            await _repository.AddAsync(ticket);

            // 4. Incrementează TicketsSold
            game.TicketsSold++;
            await _gamesRepository.UpdateAsync(game);

            // 5. Salvează tot
            await _repository.SaveChangesAsync();
            return ticket.Id;
        }

    }
}
