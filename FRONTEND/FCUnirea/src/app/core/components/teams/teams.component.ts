import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Team } from '../../models/teams-model';
import { TeamService } from '../../services/teams.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-teams',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './teams.component.html',
  styleUrl: './teams.component.scss'
})
export class TeamsComponent implements OnInit {
  internalTeams: Team[] = [];

  constructor(private teamService: TeamService, private router: Router) {}

  ngOnInit(): void {
    this.teamService.getInternalTeams().subscribe((teams) => {
      this.internalTeams = teams;
    });
  }

  goToTeam(teamId: number) {
    this.router.navigate(['/teams', teamId]);
  }
}
