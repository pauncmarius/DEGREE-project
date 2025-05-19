// TicketsService
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
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

        //
        private readonly IEmailService _emailService;
        private readonly IUsersRepository _usersRepository;
        private readonly ISeatsRepository _seatsRepository;

        public TicketsService(
            ITicketsRepository repository,
            IMapper mapper,
            IGamesRepository gamesRepository,
            IEmailService emailService,
            IUsersRepository usersRepository,
            ISeatsRepository seatsRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _gamesRepository = gamesRepository;
            _emailService = emailService;
            _usersRepository = usersRepository;
            _seatsRepository = seatsRepository;
        }

        public IEnumerable<Tickets> GetTickets() => _repository.ListAll();
        public Tickets GetTicket(int id) => _repository.GetById(id);
        public void UpdateTicket(Tickets ticket) => _repository.Update(ticket);
        public void DeleteTicket(int id)
        {
            var ticket = _repository.GetById(id);
            if (ticket != null) _repository.Delete(ticket);
        }
        public async Task<int> AddTicketAsync(TicketsModel model)
        {
            var ticket = _mapper.Map<Tickets>(model);

            var existingTickets = await _repository.ListAllAsync();

            bool isTaken = existingTickets.Any(t =>
                t.Ticket_GamesId == ticket.Ticket_GamesId &&
                t.Ticket_SeatsId == ticket.Ticket_SeatsId);

            if (isTaken)
                throw new InvalidOperationException("Locul este deja rezervat pentru acest meci.");

            var game = await _gamesRepository.GetGameWithDetailsAsync(ticket.Ticket_GamesId!.Value);
            if (game == null || !(new[] { 1, 11, 21 }.Contains(game.Game_StadiumsId ?? -1)))
                throw new InvalidOperationException("Rezervările sunt permise doar pentru stadioanele interne.");

            await _repository.AddAsync(ticket);
            game.TicketsSold++;
            await _gamesRepository.UpdateAsync(game);
            await _repository.SaveChangesAsync();

            var user = await _usersRepository.GetByIdAsync(ticket.Ticket_UsersId!.Value);
            var seat = await _seatsRepository.GetByIdAsync(ticket.Ticket_SeatsId!.Value);

            if (user != null && seat != null)
            {
                var home = game.Game_HomeTeam?.TeamName ?? "Echipă gazdă";
                var away = game.Game_AwayTeam?.TeamName ?? "Echipă oaspete";
                var matchDate = game.GameDate.ToString("dd MMM yyyy, HH:mm");
                var stadium = game.Game_Stadiums?.StadiumName ?? "Stadion necunoscut";
                var seatName = seat.SeatName;
                var seatType = seat.SeatType.ToString();
                var seatPrice = seat.SeatPrice;

                var emailBody = $@"
                    <h2>Rezervare confirmată</h2>
                    <p>Salut {user.FirstName} {user.LastName},</p>
                    <p>
                      Biletul tău pentru meciul <strong>{home}</strong> vs <strong>{away}</strong>
                      din <strong>{game.GameDate:dd MMM yyyy, HH:mm}</strong> a fost rezervat cu succes.
                    </p>
                    <p>
                      <strong>Stadion:</strong> {stadium}<br/>
                      <strong>Loc:</strong> {seatName} - {seatType} ({seatPrice} RON)
                    </p>
                    <p>Îți mulțumim că ne susții!</p>
                ";

                await _emailService.SendEmailAsync(user.Email, "Confirmare bilet FC Unirea", emailBody);
            }

            return ticket.Id;
        }


        public async Task<IEnumerable<TicketWithDetailsModel>> GetTicketsByUserIdAsync(int userId)
        {
            var tickets = await _repository.GetTicketsByUserIdAsync(userId);

            return tickets.Select(t => new TicketWithDetailsModel
            {
                Id = t.Id,
                GameDate = t.Ticket_Games?.GameDate ?? DateTime.MinValue,
                HomeTeamName = t.Ticket_Games?.Game_HomeTeam?.TeamName ?? "",
                AwayTeamName = t.Ticket_Games?.Game_AwayTeam?.TeamName ?? "",
                SeatName = t.Ticket_Seats?.SeatName ?? "",
                SeatType = t.Ticket_Seats?.SeatType.ToString() ?? "",
                SeatPrice = t.Ticket_Seats?.SeatPrice ?? 0,
                StadiumName = t.Ticket_Seats?.Seat_Stadiums?.StadiumName ?? "",
                IsPlayed = t.Ticket_Games?.IsPlayed ?? false,
                CompetitionName = t.Ticket_Games?.Game_Competitions?.CompetitionName ?? ""
            });
        }


    }
}
