import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { GameForTicket } from "../../models/game-ticket";
import { Seat } from "../../models/seat-model";
import { TicketingService } from "../../services/ticketing.service";
import { UserService } from "../../services/users.service";
import { SeatsService } from "../../services/seats.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-ticketing',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './ticketing.component.html',
  styleUrls: ['./ticketing.component.scss']
})
export class TicketingComponent implements OnInit {
  games: GameForTicket[] = [];
  selectedGameId: number | null = null;
  seats: Seat[] = [];
  selectedSeatId: number | null = null;
  userId!: number;
  gameId!: number;
  selectedStadiumName: string = '';

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
}