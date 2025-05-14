import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/users.service';
import { TicketInfo } from '../../models/tickets-model';
import { TicketingService } from '../../services/ticketing.service';
import { TicketsService } from '../../services/tickets.service';

@Component({
  selector: 'app-admin-users',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.scss']
})
export class AdminUsersComponent implements OnInit {
  users: any[] = [];
  selectedUser: any = null;
  userTickets: TicketInfo[] = [];
  activeTab: 'edit' | 'tickets' = 'edit';

  successMessage = '';
  errorMessage = '';
  searchTerm = '';

  constructor(
    private userService: UserService,
    private ticketingService: TicketingService,
    private ticketsService: TicketsService
  ) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getAllUsers().subscribe(users => this.users = users);
  }

  selectUser(user: any): void {
    this.selectedUser = { ...user };
    this.activeTab = 'edit';
    this.successMessage = '';
    this.errorMessage = '';
    this.loadTickets(user.id);
  }

  saveUser(): void {
    this.userService.updateUser(this.selectedUser).subscribe({
      next: () => {
        this.successMessage = 'Utilizator actualizat cu succes!';
        this.errorMessage = '';
        this.selectedUser = null;
        this.loadUsers();
      },
      error: () => {
        this.errorMessage = 'Eroare la actualizare.';
        this.successMessage = '';
      }
    });
  }

  deleteUser(id: number): void {
    if (confirm('Sigur vrei să ștergi acest utilizator?')) {
      this.userService.deleteUser(id).subscribe(() => this.loadUsers());
    }
  }

  get filteredUsers(): any[] {
    return this.users.filter(u =>
      u.username.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  loadTickets(userId: number): void {
    this.ticketsService.getTicketsByUser(userId).subscribe({
      next: (data) => this.userTickets = data,
      error: () => this.userTickets = []
    });
  }

  deleteTicket(id: number): void {
    if (confirm('Sigur vrei să ștergi biletul?')) {
      this.ticketingService.deleteTicket(id).subscribe(() => {
        this.loadTickets(this.selectedUser.id);
      });
    }
  }
}
