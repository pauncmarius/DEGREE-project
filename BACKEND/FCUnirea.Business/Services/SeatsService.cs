
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services
{
    public class SeatsService : ISeatsService
    {
        private readonly ISeatsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITicketsRepository _ticketsRepository;
        private readonly IGamesRepository _gamesRepository;

        public SeatsService(ISeatsRepository repository, IMapper mapper, ITicketsRepository ticketsRepo, IGamesRepository gamesRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _ticketsRepository = ticketsRepo;
            _gamesRepository = gamesRepo;
        }

        public IEnumerable<Seats> GetSeats() => _repository.ListAll();
        public Seats GetSeat(int id) => _repository.GetById(id);
        public int AddSeat(SeatsModel seat) => _repository.Add(_mapper.Map<Seats>(seat)).Id;
        public void UpdateSeat(Seats seat) => _repository.Update(seat);
        public void DeleteSeat(int id)
        {
            var seat = _repository.GetById(id);
            if (seat != null) _repository.Delete(seat);
        }

        public async Task<IEnumerable<Seats>> GetOccupiedSeatsForGameAsync(int gameId)
        {
            var tickets = await _ticketsRepository.ListAllAsync();
            var seatIds = tickets
                .Where(t => t.Ticket_GamesId == gameId && t.Ticket_SeatsId.HasValue)
            .Select(t => t.Ticket_SeatsId.Value)
                .ToHashSet();

            var allSeats = await _repository.ListAllAsync();
            return allSeats.Where(s => seatIds.Contains(s.Id));
        }
    }
}
