import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/users.service';
import { TicketsService } from '../../services/tickets.service';
import { RouterModule } from '@angular/router';
import { TicketInfo } from '../../models/tickets-model';

@Component({
  selector: 'app-my-tickets',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './my-tickets.component.html',
  styleUrls: ['./my-tickets.component.scss']
})
export class MyTicketsComponent implements OnInit {
  tickets: TicketInfo[] = [];
  loading = true;
  error = '';

  constructor(
    private userService: UserService,
    private ticketService: TicketsService
  ) {}

  ngOnInit(): void {
    const userId = this.userService.getUserIdFromToken();
    if (!userId) {
      this.error = 'Utilizator neautentificat';
      this.loading = false;
      return;
    }

    this.ticketService.getTicketsByUser(userId).subscribe({
      next: (data) => {
        this.tickets = data;
        this.loading = false;
      },
      error: () => {
        this.error = 'Nu s-au putut încărca biletele.';
        this.loading = false;
      }
    });
  }
} 