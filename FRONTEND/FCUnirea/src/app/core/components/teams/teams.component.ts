import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Team } from '../../models/teams-model';
import { TeamService } from '../../services/teams.service';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/users.service';

@Component({
  selector: 'app-teams',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './teams.component.html',
  styleUrl: './teams.component.scss'
})
export class TeamsComponent implements OnInit {
  internalTeams: Team[] = [];
  isAdmin: boolean = false;

  constructor(private teamService: TeamService, private router: Router, private userService: UserService) {}

  ngOnInit(): void {
    this.teamService.getInternalTeams().subscribe((teams) => {
      this.internalTeams = teams;
    });
    this.isAdmin = this.userService.isAdmin();
  }

  goToTeam(teamId: number) {
    this.router.navigate(['/teams', teamId]);
  }

  editTeamAdmin(event: Event, teamId: number) {
    event.stopPropagation(); // să nu declanșeze click pe card
    this.router.navigate(['/admin/teams'], { queryParams: { editId: teamId } });
  }
}
