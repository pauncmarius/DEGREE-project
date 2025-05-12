import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TeamService } from '../../services/teams.service';
import { Team } from '../../models/teams-model';

@Component({
  selector: 'app-admin-teams',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './admin-teams.component.html',
  styleUrls: ['./admin-teams.component.scss']
})
export class AdminTeamsComponent implements OnInit {
  teams: Team[] = [];
  filteredTeams: Team[] = [];
  searchTerm = '';
  editingTeam: Team | null = null;

  constructor(private teamService: TeamService) {}

  ngOnInit(): void {
    this.loadTeams();
  }

  loadTeams(): void {
    this.teamService.getTeams().subscribe(data => {
      this.teams = data;
      this.applyFilter();
    });
  }

  applyFilter(): void {
    const term = this.searchTerm.toLowerCase();
    this.filteredTeams = this.teams.filter(team =>
      team.teamName.toLowerCase().includes(term)
    );
  }

  editTeam(team: Team): void {
    this.editingTeam = { ...team };
  }

  cancelEdit(): void {
    this.editingTeam = null;
  }

  updateTeam(): void {
    if (!this.editingTeam) return;

    this.teamService.updateTeam(this.editingTeam).subscribe(() => {
      this.loadTeams();
      this.cancelEdit();
    });
  }

  deleteTeam(id: number): void {
    if (confirm('Sigur vrei să ștergi această echipă?')) {
      this.teamService.deleteTeam(id).subscribe(() => {
        this.loadTeams();
      });
    }
  }
}
