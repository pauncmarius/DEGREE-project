import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Player } from '../../models/players-model';
import { PlayersService } from '../../services/players.service';
import { Team } from '../../models/teams-model';
import { TeamService } from '../../services/teams.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-admin-players',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './admin-players.component.html',
  styleUrls: ['./admin-players.component.scss']
})
export class AdminPlayersComponent implements OnInit {
  players: Player[] = [];
  filteredPlayers: Player[] = [];
  editingPlayer: Partial<Player> = {};
  teams: Team[] = [];
  
  teamIdFilter: string = '';
  nameFilter: string = '';
  teamNameFilter: string = '';
  @ViewChild('editForm') editFormRef!: ElementRef;

  constructor(private playersService: PlayersService, private teamsService: TeamService, private route: ActivatedRoute
) {}

  ngOnInit(): void {
      this.route.queryParams.subscribe(params => {
      if (params['teamName']) {
        this.teamNameFilter = params['teamName'];
      }
      this.loadPlayers();
    });
    this.teamsService.getTeams().subscribe(t => this.teams = t);
  }

  loadPlayers(): void {
    this.playersService.getPlayers().subscribe(data => {
      this.players = data;
      this.applyFilters();
    });
  }

  applyFilters(): void {
    const name = this.nameFilter.trim().toLowerCase();
    const team = this.teamNameFilter.trim().toLowerCase();

    this.filteredPlayers = this.players.filter(player => {
      const matchesName = player.playerName.toLowerCase().includes(name);
      const matchesTeam = !team || (player.teamName?.toLowerCase().includes(team));
      return matchesName && matchesTeam;
    });
  }



  submitPlayer(): void {
    // Dacă editezi un jucător existent
    if (this.editingPlayer.id) {
      if (!confirm('Sigur vrei să salvezi modificările pentru acest jucător?')) return;
      this.playersService.updatePlayer(this.editingPlayer as Player).subscribe(() => {
        alert('Jucătorul a fost actualizat cu succes!');
        this.loadPlayers();
        this.cancelEditPlayer();
      });
    } else {
      // La adăugare poți pune confirmare, sau direct succes
      this.playersService.addPlayer(this.editingPlayer as Player).subscribe(() => {
        alert('Jucător adăugat cu succes!');
        this.loadPlayers();
        this.cancelEditPlayer();
      });
    }
  }


  editPlayer(player: Player): void {
    this.editingPlayer = { ...player };
    setTimeout(() => {
      this.editFormRef?.nativeElement.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }, 20);
  }

  cancelEditPlayer(): void {
    this.editingPlayer = {};
  }

  deletePlayer(id: number): void {
    if (confirm('Ești sigur că vrei să ștergi acest jucător?')) {
      this.playersService.deletePlayer(id).subscribe(() => {
        this.loadPlayers();
      });
    }
  }
}
