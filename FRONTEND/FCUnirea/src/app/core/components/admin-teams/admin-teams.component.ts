import { Component, OnInit, ViewChildren, QueryList, ElementRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TeamService } from '../../services/teams.service';
import { Team } from '../../models/teams-model';
import { ActivatedRoute } from '@angular/router';

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

  @ViewChildren('editForm') editForms!: QueryList<ElementRef>;

  constructor(private teamService: TeamService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.loadTeams();
  }

  loadTeams(): void {
    this.teamService.getTeams().subscribe(data => {
      this.teams = data;
      this.applyFilter();

      // reia din query param dacă există
      const editId = +this.route.snapshot.queryParamMap.get('editId')!;
      if (editId) {
        const t = this.teams.find(team => team.id === editId);
        if (t) {
          this.editingTeam = { ...t };
          // scroll după ce formularul apare (next tick!)
          setTimeout(() => {
            const el = this.editForms.find(ref => !!ref.nativeElement.offsetParent);
            if (el) {
              el.nativeElement.scrollIntoView({ behavior: 'smooth', block: 'center' });
            }
          }, 70);
        }
      }
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
    setTimeout(() => {
      const el = this.editForms.find(ref => !!ref.nativeElement.offsetParent);
      if (el) {
        el.nativeElement.scrollIntoView({ behavior: 'smooth', block: 'center' });
      }
    }, 60);
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
    const team = this.teams.find(t => t.id === id);
    const teamName = team ? team.teamName : '';
    if (confirm(`Ești sigur că vrei să ștergi echipa "${teamName}"?\nAcțiunea este ireversibilă!`)) {
      this.teamService.deleteTeam(id).subscribe(() => {
        this.loadTeams();
      });
    }
  }

}
