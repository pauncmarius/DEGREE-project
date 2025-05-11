import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/users.service';

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
  successMessage = '';
  errorMessage = '';
  searchTerm = '';

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getAllUsers().subscribe(users => {
      this.users = users;
    });
  }

  selectUser(user: any): void {
    this.selectedUser = { ...user }; // Clone pentru a nu edita direct
    this.successMessage = '';
    this.errorMessage = '';
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
        this.errorMessage = 'Eroare la actualizarea utilizatorului.';
        this.successMessage = '';
      }
    });
  }

  deleteUser(id: number): void {
    if (confirm('Sigur vrei să ștergi acest utilizator?')) {
      this.userService.deleteUser(id).subscribe(() => {
        this.loadUsers();
      });
    }
  }

  get filteredUsers(): any[] {
    return this.users.filter(u =>
      u.username.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}
