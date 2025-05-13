import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Game } from '../../models/games-model';
import { GameScorer } from '../../models/game-scorer-model';
import { Player } from '../../models/players-model';
import { GamesService } from '../../services/games.service';
import { PlayersService } from '../../services/players.service';
import { PlayerStatisticsPerGameService } from '../../services/player-statistics-per-game.service';

@Component({
  selector: 'app-admin-games',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './admin-games.component.html',
  styleUrls: ['./admin-games.component.scss']
})
export class AdminGamesComponent implements OnInit {
  games: Game[] = [];
  filteredGames: Game[] = [];
  selectedGame: Game | null = null;
  scorers: GameScorer[] = [];
  players: Player[] = [];
  newScorer: { playerId: number | null; goals: number } = { playerId: null, goals: 1 };
  searchTerm = '';

  constructor(
    private gamesService: GamesService,
    private playersService: PlayersService,
    private statsService: PlayerStatisticsPerGameService
  ) {}

  ngOnInit(): void {
    this.gamesService.getGames().subscribe(data => {
      this.games = data;
      this.filteredGames = data;
    });
  }

  filterGames(): void {
    const term = this.searchTerm.toLowerCase();
    this.filteredGames = this.games.filter(g =>
      g.homeTeamName.toLowerCase().includes(term) ||
      g.awayTeamName.toLowerCase().includes(term)
    );
  }

  selectGame(game: Game): void {
    this.selectedGame = game;
    this.statsService.getScorersByGame(game.id).subscribe(data => this.scorers = data);

    const teamIds = [game.game_HomeTeamId, game.game_AwayTeamId];
    this.players = [];
    teamIds.forEach(id => {
      this.playersService.getPlayersByTeam(id).subscribe(data => this.players.push(...data));
    });
  }

  addScorer(): void {
    if (!this.newScorer.playerId || !this.selectedGame) return;
    this.statsService.addScorer({
      goals: this.newScorer.goals,
      playerStatisticsPerGame_PlayersId: this.newScorer.playerId,
      playerStatisticsPerGame_GamesId: this.selectedGame.id
    }).subscribe(() => this.selectGame(this.selectedGame!));
    this.newScorer = { playerId: null, goals: 1 };
  }

  deleteScorer(scorer: GameScorer): void {
    const found = this.scorers.find(s => s.playerName === scorer.playerName && s.goals === scorer.goals);
    if (!found || !this.selectedGame) return;
    this.statsService.deleteScorer(found.id!).subscribe(() => this.selectGame(this.selectedGame!));
  }
}