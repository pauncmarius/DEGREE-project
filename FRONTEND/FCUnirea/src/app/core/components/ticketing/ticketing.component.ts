import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { GameForTicket } from "../../models/game-ticket";
import { Seat } from "../../models/seat-model";
import { TicketingService } from "../../services/ticketing.service";
import { UserService } from "../../services/users.service";
import { SeatsService } from "../../services/seats.service";
import { ActivatedRoute } from "@angular/router";
import { ViewChild, ElementRef } from '@angular/core';


@Component({
  selector: 'app-ticketing',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './ticketing.component.html',
  styleUrls: ['./ticketing.component.scss']
})
export class TicketingComponent implements OnInit {
   @ViewChild('stadiumZone') stadiumZone!: ElementRef;
  games: GameForTicket[] = [];
  selectedGameId: number | null = null;
  seats: Seat[] = [];
  selectedSeatId: number | null = null;
  userId!: number;
  gameId!: number;
  selectedStadiumName: string = '';
  searchTerm: string = '';
  searchDate: string = '';


  constructor(
    private ticketService: TicketingService,
    private userService: UserService,
    private route: ActivatedRoute,
    private seatService: SeatsService
  ) {}

  ngOnInit() {
    const userId = this.userService.getUserIdFromToken();
    if (userId === null) {
      alert('Nu ești autentificat. Nu poți face rezervări.');
      return;
    }
    this.userId = userId;

    this.ticketService.getAvailableGames().subscribe(g => this.games = g);

    this.gameId = Number(this.route.snapshot.paramMap.get('gameId'));
    if (this.gameId) {
      this.selectedGameId = this.gameId;
      this.loadSeats(this.gameId);
    }
  }

  onSelectGame(gameId: number) {
    this.selectedGameId = gameId;
    this.loadSeats(gameId);
    setTimeout(() => {
      // Dă scroll smooth la stadion
      this.stadiumZone?.nativeElement.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }, 50);
  }

  loadSeats(gameId: number) {
    this.seatService.getSeatsByGame(gameId).subscribe(seats => {
      this.seats = seats;
      if (seats.length > 0) {
        this.selectedStadiumName = seats[0]?.stadiumName || 'Stadion necunoscut';
      }
    });
  }

  onReserve() {
    if (!this.userId || !this.selectedGameId || !this.selectedSeatId) {
      alert('Selectează un meci și un loc disponibil.');
      return;
    }

    // Pas suplimentar: confirmare
    const selectedGame = this.games.find(g => g.id === this.selectedGameId);
    const selectedSeat = this.seats.find(s => s.id === this.selectedSeatId);

    const msg = `Ești sigur că vrei să rezervi următorul bilet?\n\n` +
      `Meci: ${selectedGame?.homeTeamName} vs ${selectedGame?.awayTeamName}\n` +
      `Data: ${selectedGame?.gameDate ? new Date(selectedGame.gameDate).toLocaleString('ro-RO') : '-'}\n` +
      `Loc: ${selectedSeat?.seatName || '-'} (${selectedSeat?.seatType || '-'})\n` +
      `Preț: ${selectedSeat?.seatPrice || '-'} RON`;

    if (!window.confirm(msg)) {
      return; // Utilizatorul a anulat
    }

    // Dacă a confirmat, trimite rezervarea
    this.ticketService.reserveTicket({
      ticket_UsersId: this.userId,
      ticket_GamesId: this.selectedGameId,
      ticket_SeatsId: this.selectedSeatId
    }).subscribe({
      next: () => alert('Rezervare realizată cu succes!'),
      error: err => alert(err.error.message || 'Eroare la rezervare')
    });
  }

  onSelectSeat(seatId: number) {
    this.selectedSeatId = seatId;
  }

  get filteredGames(): GameForTicket[] {
  return this.games.filter(g => {
    // Filtru pe nume (meci)
    const searchText = this.searchTerm.trim().toLowerCase();
    const nameMatch =
      !searchText ||
      g.homeTeamName.toLowerCase().includes(searchText) ||
      g.awayTeamName.toLowerCase().includes(searchText);

    // Filtru pe dată (YYYY-MM-DD din input type="date")
    const dateMatch =
      !this.searchDate ||
      (g.gameDate && new Date(g.gameDate).toISOString().slice(0, 10) === this.searchDate);

    return nameMatch && dateMatch;
  });
}

}