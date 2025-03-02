import { Injectable } from '@angular/core';
import { users } from '../mocks/users-mock';
import { User } from '../../shared/models/user-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  mockUsers = users;

  getMockUsers(): User[] {
    return this.mockUsers
  }

  addMockUser(user: User): void {
    users.unshift(user);
  }

  removeMockUser(id: string): void {
    users.shift();
  }

}
