import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/users.service';
import { TicketInfo } from '../../models/tickets-model';
import { TicketingService } from '../../services/ticketing.service';
import { TicketsService } from '../../services/tickets.service';
import { ActivatedRoute } from '@angular/router';

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
    private ticketsService: TicketsService,
    private route: ActivatedRoute 
  ) {}

  ngOnInit(): void {
    this.loadUsers();

    this.route.queryParams.subscribe(params => {
    const id = Number(params['editUserId']);
    if (id) {
      // așteaptă încărcarea userilor (users se încarcă asincron)
      setTimeout(() => this.trySelectUserById(id), 500);
    }
  });
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
    const term = this.searchTerm.trim().toLowerCase();
    return this.users.filter(u =>
      u.username.toLowerCase().includes(term) ||
      u.email.toLowerCase().includes(term)   // <-- Adăugat
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

  trySelectUserById(userId: number) {
  const user = this.users.find(u => u.id === userId);
  if (user) {
    this.selectUser(user);
    setTimeout(() => {
      // scroll la zona de edit (poți ajusta selectorul după structură)
      const el = document.querySelector('.edit-form-inline');
      if (el) el.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }, 100);
  }
}

}
