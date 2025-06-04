import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Game } from '../../models/games-model';
import { GameScorer } from '../../models/game-scorer-model';
import { Player } from '../../models/players-model';
import { GamesService } from '../../services/games.service';
import { PlayersService } from '../../services/players.service';
import { PlayerStatisticsPerGameService } from '../../services/player-statistics-per-game.service';
import { Team } from '../../models/teams-model';
import { CompetitionsModel } from '../../models/competitions-model';
import { TeamService } from '../../services/teams.service';
import { CompetitionService } from '../../services/competitions.service';
import { ActivatedRoute } from '@angular/router';


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
  //
  editingGame: any = {};
  isCreatingNewGame = false;
  allTeams: Team[] = [];
  competitions: CompetitionsModel[] = [];
  //
  
  constructor(
    private gamesService: GamesService,
    private playersService: PlayersService,
    private statsService: PlayerStatisticsPerGameService,
    private teamsService: TeamService,
    private competitionsService: CompetitionService,
    private route: ActivatedRoute


  ) {}

  ngOnInit(): void {
    this.gamesService.getGames().subscribe(data => {
      this.games = data;
      this.filteredGames = data;

      const editGameId = Number(this.route.snapshot.queryParamMap.get('editGameId'));
      if (editGameId && data.some(g => g.id === editGameId)) {
        this.selectGame(data.find(g => g.id === editGameId)!);
      }
    });
    
    this.teamsService.getTeams().subscribe(data => this.allTeams = data);
    this.competitionsService.getAll().subscribe(data => this.competitions = data);
  }

    filterGames(): void {
      let term = this.searchTerm.trim().toLowerCase();
      if (!term) {
        this.filteredGames = this.games;
        return;
      }
      // ignoră "vs" dacă apare în căutare
      const keywords = term.replace(/vs/g, '').split(/\s+/).filter(Boolean);

      this.filteredGames = this.games.filter(game => {
        const home = game.homeTeamName.toLowerCase();
        const away = game.awayTeamName.toLowerCase();
        return keywords.every(kw => home.includes(kw) || away.includes(kw));
      });
    }


  selectGame(game: Game): void {
    this.selectedGame = game;
    this.isCreatingNewGame = false;
    this.editingGame = { ...game };
      // ia marcatorii pentru acest meci
      this.statsService.getScorersByGame(game.id).subscribe(data => this.scorers = data);
      const teamIds = [game.game_HomeTeamId, game.game_AwayTeamId];
      this.players = [];
      // ia jucatorii pentru fiecare echipa si-i adauga in lista
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
    if (confirm('Ești sigur că vrei să ștergi acest marcator? Acțiunea nu poate fi anulată!')) {
      const found = this.scorers.find(s => s.playerName === scorer.playerName && s.goals === scorer.goals);
      if (!found || !this.selectedGame) return;
      this.statsService.deleteScorer(found.id!).subscribe(() => this.selectGame(this.selectedGame!));}
  }

  
  startCreatingGame() {
    this.editingGame = {
      gameDate: '',
      homeTeamScore: 0,
      awayTeamScore: 0,
      game_HomeTeamId: null,
      game_AwayTeamId: null,
      game_CompetitionsId: null,
      refereeName: '',

      isPlayed: false
    };
    this.isCreatingNewGame = true;
    this.selectedGame = null;
    this.scorers = [];
    this.players = [];
  }

  cancelGameEdit() {
    this.isCreatingNewGame = false;
    this.editingGame = {};
    this.selectedGame = null;
    this.scorers = [];
    this.players = [];
  }
  
  submitGame(): void {
    // elimină scorurile din obiect dacă vrei explicit:
    delete this.editingGame.homeTeamScore;
    delete this.editingGame.awayTeamScore;
    this.editingGame.game_StadiumsId = this.editingGame.game_HomeTeamId;
    if (!this.editingGame.refereeName) {
      this.editingGame.refereeName = "Nespecificat";
    }

    if (this.isCreatingNewGame) {
      this.gamesService.addGame(this.editingGame).subscribe(() => {
        this.isCreatingNewGame = false;
        this.loadGames();
      });
    } else if (this.selectedGame) {
      this.gamesService.updateGame({ ...this.selectedGame, ...this.editingGame }).subscribe(() => {
        this.loadGames();
        this.selectedGame = null;
        this.editingGame = {};
      });
    }
  }

  loadGames() {
    this.gamesService.getGames().subscribe(data => {
      this.games = data;
      this.filteredGames = data;
    });
  }
  deleteGame() {
  if (confirm('Ești sigur că vrei să ștergi acest meci? Acțiunea nu poate fi anulată!')) {
      this.gamesService.deleteGame(this.editingGame.id).subscribe(() => {
        this.cancelGameEdit();
        this.loadGames();
      });
    }
  }
}