import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { User } from '../../../shared/models/user-model';
import { from, map, Subscription } from 'rxjs';

@Component({
  selector: 'app-user-overview',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-overview.component.html',
  styleUrl: './user-overview.component.scss'
})
export class UserOverviewComponent implements OnInit{
  mockUsers: User[] = [];
  mySubscription: Subscription = Subscription.EMPTY;
  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.mockUsers = this.userService.getMockUsers();
    this.runExamples();
  }
  ngOnDestroy(): void{
    this.mySubscription.unsubscribe();
  }

  addMockUser(): void {
    const newUser: User = {
        id: '1234',
        role: 'admin',
        name: 'Gigel',
        avatar: 'https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Cat03.jpg/1200px-Cat03.jpg',
        age: 20,
    };

    this.userService.addMockUser(newUser);
  }

  removeMockUser(){
    this.userService.removeMockUser('')
  }

  runExamples(): void {
    this.mySubscription = from(this.mockUsers).subscribe(value => console.log(value));

    from(this.mockUsers).pipe(
        map((value: User) => {
            value.age = value.age - 10;
            return value;
        })
    ).subscribe(value => console.log(value));
  }


}
