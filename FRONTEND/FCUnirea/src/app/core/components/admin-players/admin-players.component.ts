import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Player } from '../../models/players-model';
import { PlayersService } from '../../services/players.service';

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

  teamIdFilter: string = '';
  nameFilter: string = '';

  constructor(private playersService: PlayersService) {}

  ngOnInit(): void {
    this.loadPlayers();
  }

  loadPlayers(): void {
    this.playersService.getPlayers().subscribe(data => {
      this.players = data;
      this.applyFilters();
    });
  }

  applyFilters(): void {
    const teamIdNumber = parseInt(this.teamIdFilter, 10);

    this.filteredPlayers = this.players.filter(player => {
      const matchesTeamId = isNaN(teamIdNumber) || player.player_TeamsId === teamIdNumber;
      const matchesName = player.playerName.toLowerCase().includes(this.nameFilter.toLowerCase());
      return matchesTeamId && matchesName;
    });
  }


  submitPlayer(): void {
    if (this.editingPlayer.id) {
      this.playersService.updatePlayer(this.editingPlayer as Player).subscribe(() => {
        this.loadPlayers();
        this.cancelEditPlayer();
      });
    } else {
      this.playersService.addPlayer(this.editingPlayer as Player).subscribe(() => {
        this.loadPlayers();
        this.cancelEditPlayer();
      });
    }
  }

  editPlayer(player: Player): void {
    this.editingPlayer = { ...player };
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
