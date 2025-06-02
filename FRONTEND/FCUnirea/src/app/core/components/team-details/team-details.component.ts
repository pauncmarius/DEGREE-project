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
import { FormsModule } from '@angular/forms';
import { BracketMatch, CupRound } from '../../models/cup-model';
import { Router } from '@angular/router';
import { UserService } from '../../services/users.service';

@Component({
  selector: 'app-team-details',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './team-details.component.html',
  styleUrl: './team-details.component.scss'
})

export class TeamDetailsComponent implements OnInit {
  objectKeys = Object.keys;

  team!: Team;
  teamId!: number;
  games: Game[] = [];
  players: Player[] = [];
  isAdmin = false;

  standingsMap: { [competitionId: number]: TeamStatistic[] } = {};
  competitionNames: { [competitionId: number]: string } = {};

  scorersMap: { [competitionId: number]: Scorer[] } = {};
  activeMainTab: 'lot' | 'program' | 'clasament' = 'lot';
  activeTabMap: { [compId: number]: 'standings' | 'scorers' | 'brackets' } = {};

  selectedGameId: number | null = null;
  scorersPerGame: { [gameId: number]: GameScorer[] } = {};

  groupedPlayers: { [position: string]: Player[] } = {};

  searchMatchTerm = '';

  cupBrackets: { [competitionId: number]: CupRound[] } = {};

  constructor(
    private route: ActivatedRoute,
    private teamService: TeamService,
    private gamesService: GamesService,
    private playersService: PlayersService,
    private statsService: TeamStatisticsService,
    private scorersService: PlayerStatisticsPerCompetitionService,
    private playerStatsService: PlayerStatisticsPerGameService,
    private router: Router,
    private userService: UserService 
  ) {}

  ngOnInit(): void {
    this.teamId = Number(this.route.snapshot.paramMap.get('id'));
    this.isAdmin = this.userService.isAdmin();
    this.teamService.getTeamById(this.teamId).subscribe(team => {
      this.team = team;
    });

    // Ia meciurile pentru tab Program și identifică toate competițiile la care participă
    this.gamesService.getGamesByTeam(this.teamId).subscribe(games => {
      this.games = games;

      const uniqueCompetitions = [...new Set(games.map(g => g.game_CompetitionsId))];

      // Populezi numele pentru taburi
      for (const competitionId of uniqueCompetitions) {
        const compGames = games.find(g => g.game_CompetitionsId === competitionId);
        if (compGames) {
          this.competitionNames[competitionId] = compGames.competitionName;
        }
      }

      for (const competitionId of uniqueCompetitions) {
        const compName = this.competitionNames[competitionId];
        this.activeTabMap[competitionId] = this.isCup(compName) ? 'brackets' : 'standings';

        // Brackets - toate meciurile din cupă
        if (this.isCup(compName)) {
          this.gamesService.getGamesByCompetition(competitionId).subscribe(allCupGames => {
            this.cupBrackets[competitionId] = this.generateBracketsByIndex(allCupGames);
          });
        }

        // Standings și marcatori
        this.statsService.getStandingsByCompetition(competitionId).subscribe(standings => {
          this.standingsMap[competitionId] = standings;
          this.scorersService.getTopScorersByCompetition(competitionId).subscribe(scorers => {
            this.scorersMap[competitionId] = scorers;
          });
        });
      }
    });

    this.playersService.getPlayersByTeam(this.teamId).subscribe(players => {
      this.players = players;
      this.groupPlayersByPosition();
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
    if (!game.isPlayed) return 'not-played';
    const isHomeTeam = game.game_HomeTeamId === this.teamId;
    const teamScore = isHomeTeam ? game.homeTeamScore : game.awayTeamScore;
    const opponentScore = isHomeTeam ? game.awayTeamScore : game.homeTeamScore;
    if (teamScore > opponentScore) return 'win';
    if (teamScore < opponentScore) return 'loss';
    return 'draw';
  }
  
  groupPlayersByPosition() {
    this.groupedPlayers = {};
    for (const player of this.players) {
      const pos = player.position || 'Necunoscut';
      if (!this.groupedPlayers[pos]) {
        this.groupedPlayers[pos] = [];
      }
      this.groupedPlayers[pos].push(player);
    }
  }

  get filteredGames(): Game[] {
    const term = this.searchMatchTerm.trim().toLowerCase();
    if (!term) return this.games;
    return this.games.filter(g =>
      g.homeTeamName.toLowerCase().includes(term) ||
      g.awayTeamName.toLowerCase().includes(term) ||
      g.competitionName.toLowerCase().includes(term)
    );
  }

  isCup(name: string | undefined): boolean {
    if (!name) return false;
    const nameLower = name.toLowerCase();
    return nameLower.includes('cup') || nameLower.includes('cupă') || nameLower.includes('cupa');
  }

  generateBracketsByIndex(games: Game[]): CupRound[] {
    const sortedGames = [...games].sort((a, b) => new Date(a.gameDate).getTime() - new Date(b.gameDate).getTime());
    const faze = [
      { nume: 'Optimi', count: 8 },
      { nume: 'Sferturi', count: 4 },
      { nume: 'Semifinale', count: 2 },
      { nume: 'Finală', count: 1 },
    ];

    let idx = 0;
    const rounds: CupRound[] = [];

    for (const faza of faze) {
      // Ia întâi toate tururile, apoi toate retururile pentru această fază!
      const tururi = sortedGames.slice(idx, idx + faza.count);
      const retururi = sortedGames.slice(idx + faza.count, idx + 2 * faza.count);

      const matches: BracketMatch[] = [];
      for (let i = 0; i < faza.count; i++) {
        const firstLeg = tururi[i];
        const secondLeg = retururi[i];

        // calculează scorul cum trebuie:
        let aggregateScore = '', winner = '';
        if (firstLeg && secondLeg && firstLeg.isPlayed && secondLeg.isPlayed) {
          const team1Goals = firstLeg.homeTeamScore + secondLeg.awayTeamScore;
          const team2Goals = firstLeg.awayTeamScore + secondLeg.homeTeamScore;
          aggregateScore = `${team1Goals}-${team2Goals}`;
          if (team1Goals > team2Goals) winner = firstLeg.homeTeamName;
          else if (team2Goals > team1Goals) winner = firstLeg.awayTeamName;
          else winner = 'Egalitate';
        }

        matches.push({
          homeTeam: firstLeg?.homeTeamName ?? '',
          awayTeam: firstLeg?.awayTeamName ?? '',
          firstLeg,
          secondLeg,
          aggregateScore: aggregateScore || undefined,
          winner: winner || undefined,
        });
      }
      if (matches.length > 0) {
        rounds.push({ name: faza.nume, matches });
      }
      idx += faza.count * 2; // Treci la faza următoare!
    }
    return rounds;
  }



  getCupBrackets(compId: number): CupRound[] {
    return this.cupBrackets[compId] || [];
  }

  displayScore(game: Game, side: 'home' | 'away'): string {
  if (!game.isPlayed) return '';
  return side === 'home' ? game.homeTeamScore.toString() : game.awayTeamScore.toString();
  }

  editSquad() {
    // Navighează cu query param pentru filtru după echipa curentă
    this.router.navigate(['/admin/players'], {
      queryParams: { teamName: this.team.teamName }
  });

}}
