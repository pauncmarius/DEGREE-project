import { CommonModule } from '@angular/common';
import { Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { User } from '../../../shared/models/user-model';
import { from, map, Subscription } from 'rxjs';
import { UserService } from '../../../core/services/user-service.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-user-overview',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './user-overview.component.html',
  styleUrl: './user-overview.component.scss'
})
export class UserOverviewComponent implements OnInit{
  users: User[] = [];

  private userService = inject(UserService);

  ngOnInit(): void {
    this.getUsers();
  }
  ngOnDestroy(): void{
  }

  getUsers(): void {
    this.userService.getUsers().subscribe(
      (data: User[]) => {
        this.users = data;
      },
      (error) => {
        console.error('Error fetching users:', error);
      }
    );
  }
}
