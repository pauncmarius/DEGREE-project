import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CompetitionService } from '../../services/competitions.service';
import { CompetitionsModel } from '../../models/competitions-model';

@Component({
  selector: 'app-admin-competitions',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './admin-competitions.component.html',
  styleUrls: ['./admin-competitions.component.scss']
})
export class AdminCompetitionsComponent implements OnInit {
  competitions: CompetitionsModel[] = [];
  editingCompetition: CompetitionsModel = { competitionName: '', competitionType: 'NationalLeague' };
  isEditing = false;

  constructor(private competitionService: CompetitionService) {}

  ngOnInit(): void {
    this.loadCompetitions();
  }

  loadCompetitions(): void {
    this.competitionService.getAll().subscribe(data => this.competitions = data);
  }

  startEdit(c: CompetitionsModel): void {
    this.editingCompetition = { ...c };
    this.isEditing = true;
  }

  cancelEdit(): void {
    this.editingCompetition = { competitionName: '', competitionType: 'NationalLeague' };
    this.isEditing = false;
  }

  submitCompetition(): void {
    if (this.editingCompetition.id) {
      this.competitionService.update(this.editingCompetition).subscribe(() => {
        this.loadCompetitions();
        this.cancelEdit();
      });
    } else {
      this.competitionService.add(this.editingCompetition).subscribe(() => {
        this.loadCompetitions();
        this.cancelEdit();
      });
    }
  }

  deleteCompetition(id: number): void {
    if (confirm('Ștergi această competiție?')) {
      this.competitionService.delete(id).subscribe(() => this.loadCompetitions());
    }
  }
}
