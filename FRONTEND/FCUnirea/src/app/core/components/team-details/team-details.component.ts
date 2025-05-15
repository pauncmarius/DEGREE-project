import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { TeamService } from '../../services/teams.service';
import { Team } from '../../models/teams-model';
import { GamesService } from '../../services/games.service';
import { Game } from '../../models/games-model';
import { Player } from '../../models/players-model';
import { PlayersService } from '../../services/players.service';
import { TeamStatistic } from '../../models/team-stats-model';
import { TeamStatisticsService } from '../../services/team-statistics.service';

import { Scorer } from '../../models/scorers-model';
import { GameScorer } from '../../models/game-scorer-model';
import { PlayerStatisticsPerGameService } from '../../services/player-statistics-per-game.service';
import { PlayerStatisticsPerCompetitionService } from '../../services/player-statistics-per-competition.service';
@Component({
  selector: 'app-team-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './team-details.component.html',
  styleUrl: './team-details.component.scss'
})
export class TeamDetailsComponent implements OnInit {
  team!: Team;
  teamId!: number;
  games: Game[] = [];
  players: Player[] = [];

  standingsMap: { [competitionId: number]: TeamStatistic[] } = {};
  competitionNames: { [competitionId: number]: string } = {};

  scorersMap: { [competitionId: number]: Scorer[] } = {};
  activeTabMap: { [competitionId: number]: 'standings' | 'scorers' } = {};

  selectedGameId: number | null = null;
  scorersPerGame: { [gameId: number]: GameScorer[] } = {};

  constructor(
    private route: ActivatedRoute,
    private teamService: TeamService,
    private gamesService: GamesService,
    private playersService: PlayersService,
    private statsService: TeamStatisticsService,
    private scorersService: PlayerStatisticsPerCompetitionService,
    private playerStatsService: PlayerStatisticsPerGameService

  ) {}

  ngOnInit(): void {
    this.teamId = Number(this.route.snapshot.paramMap.get('id'));

    this.teamService.getTeamById(this.teamId).subscribe(team => {
      this.team = team;
    });

    this.gamesService.getGamesByTeam(this.teamId).subscribe(games => {
      this.games = games;

      // extrage toate competitiile distincte
      const uniqueCompetitions = [...new Set(games.map(g => g.game_CompetitionsId))];

      for (const competitionId of uniqueCompetitions) {
        const compGames = games.find(g => g.game_CompetitionsId === competitionId);
        if (compGames) {
          this.competitionNames[competitionId] = compGames.competitionName;
        }
      
        this.statsService.getStandingsByCompetition(competitionId).subscribe(standings => {
          this.standingsMap[competitionId] = standings;
          this.activeTabMap[competitionId] = 'standings';
      
          // doar aici putem accesa competitionId in context
          this.scorersService.getTopScorersByCompetition(competitionId).subscribe(scorers => {
            this.scorersMap[competitionId] = scorers;
          });
        });
      }
    });

    this.playersService.getPlayersByTeam(this.teamId).subscribe(players => {
      this.players = players;
    });

    
  }

  calculateAge(birthDateStr: string): number {
    const birthDate = new Date(birthDateStr);
    const today = new Date();
    let age = today.getFullYear() - birthDate.getFullYear();
    const hasBirthdayPassed =
      today.getMonth() > birthDate.getMonth() ||
      (today.getMonth() === birthDate.getMonth() && today.getDate() >= birthDate.getDate());
    return hasBirthdayPassed ? age : age - 1;
  }

  get standingsCompetitionIds(): number[] {
    return Object.keys(this.standingsMap).map(Number);
  }
  
  toggleScorers(gameId: number): void {
    this.selectedGameId = this.selectedGameId === gameId ? null : gameId;
  
    if (!this.scorersPerGame[gameId]) {
      this.playerStatsService.getScorersByGame(gameId).subscribe((data) => {
        this.scorersPerGame[gameId] = data;
      });
    }
  }

  getMatchResultClass(game: Game): string {
    console.log({
      teamId: this.teamId,
      homeTeamId: game.game_HomeTeamId,
      awayTeamId: game.game_AwayTeamId,
      homeScore: game.homeTeamScore,
      awayScore: game.awayTeamScore
    });
    
    if (!game.isPlayed) return 'not-played';
  
    const isHomeTeam = game.game_HomeTeamId === this.teamId;
    const teamScore = isHomeTeam ? game.homeTeamScore : game.awayTeamScore;
    const opponentScore = isHomeTeam ? game.awayTeamScore : game.homeTeamScore;
  
    if (teamScore > opponentScore) return 'win';
    if (teamScore < opponentScore) return 'loss';
    return 'draw';
  }
  
  
}
