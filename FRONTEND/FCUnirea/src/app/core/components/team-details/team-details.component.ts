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
import { TicketInfo } from '../../models/tickets-model';
import { TicketsService } from '../../services/tickets.service';
import { forkJoin, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import {
  Chart,
  CategoryScale,
  LinearScale,
  BarController,
  BarElement,
  Tooltip,
  Legend,
  ArcElement,
  PieController,
  Title
} from 'chart.js';

Chart.register(
  CategoryScale,
  LinearScale,
  BarController,
  BarElement,
  Tooltip,
  Legend,
  ArcElement,
  PieController,
  Title
);



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

  ticketsPerGame: { [gameId: number]: TicketInfo[] } = {};
  ticketCountPerGame: { [gameId: number]: number } = {};
  ticketTotalPricePerGame: { [gameId: number]: number } = {};
  ticketChartInstances: { [gameId: number]: Chart } = {};

  goalsPerPlayer: { [playerName: string]: number } = {};
  totalTeamGoals: number = 0;
  numMatchesPlayed: number = 0;
  goalsPieChartInstance?: Chart;
  
  constructor(
    private route: ActivatedRoute,
    private teamService: TeamService,
    private gamesService: GamesService,
    private playersService: PlayersService,
    private statsService: TeamStatisticsService,
    private scorersService: PlayerStatisticsPerCompetitionService,
    private playerStatsService: PlayerStatisticsPerGameService,
    private router: Router,
    private ticketsService: TicketsService, 
    private userService: UserService 
  ) {}

  ngOnInit(): void {
    this.teamId = Number(this.route.snapshot.paramMap.get('id'));
    this.isAdmin = this.userService.isAdmin();
    this.teamService.getTeamById(this.teamId).subscribe(team => {
      this.team = team;});

    this.gamesService.getGamesByTeam(this.teamId).subscribe(games => {
      this.games = games;
      this.buildGoalsDistribution();

      const uniqueCompetitions = [...new Set(games.map(g => g.game_CompetitionsId))];

      for (const competitionId of uniqueCompetitions) {
        const compGames = games.find(g => g.game_CompetitionsId === competitionId);
        if (compGames) {
          this.competitionNames[competitionId] = compGames.competitionName;
        }
      }

      for (const competitionId of uniqueCompetitions) {
        const compName = this.competitionNames[competitionId];
        this.activeTabMap[competitionId] = this.isCup(compName) ? 'brackets' : 'standings';

        if (this.isCup(compName)) {
          this.gamesService.getGamesByCompetition(competitionId).subscribe(allCupGames => {
            this.cupBrackets[competitionId] = this.generateBracketsByIndex(allCupGames);
          });
        }

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
      this.playerStatsService.getScorersByGame(gameId).subscribe(data => {
        this.scorersPerGame[gameId] = data;
      });
    }

    const game = this.games.find(g => g.id === gameId)!;

    if (this.isHomeGame(game)) {
      if (!this.ticketsPerGame[gameId]) {
        this.ticketsService.getTicketsByGame(gameId).subscribe(tickets => {
          this.ticketsPerGame[gameId] = tickets;
          this.ticketCountPerGame[gameId] = tickets.length;

          this.ticketTotalPricePerGame[gameId] = tickets
            .map(t => t.seatPrice)
            .reduce((sum, price) => sum + price, 0);

          this.scheduleChartBuild(gameId, tickets);
        });
      } else {

        if (this.selectedGameId === gameId) {
          this.scheduleChartBuild(gameId, this.ticketsPerGame[gameId]);
        }
      }

    } else {

    }
  }

  private scheduleChartBuild(gameId: number, tickets: TicketInfo[]) {
    setTimeout(() => {
      const canvasEl = document.getElementById(`ticketCanvas-${gameId}`) as HTMLCanvasElement;
      if (!canvasEl) {
        console.warn(`Canvas-ul pentru gameId=${gameId} lipsește în DOM.`);
        return;
      }

      if (this.ticketChartInstances[gameId]) {
        this.ticketChartInstances[gameId].destroy();
      }

      const grouping = tickets.reduce((acc: Record<string, number>, t: TicketInfo) => {
        const key = t.seatType || 'Necunoscut';
        acc[key] = (acc[key] || 0) + 1;
        return acc;
      }, {});
      const labels = Object.keys(grouping);
      const data = labels.map(label => grouping[label]);

      const ctx = canvasEl.getContext('2d');
      if (!ctx) {
        console.warn(`Nu s-a putut obține context pentru canvas gameId=${gameId}.`);
        return;
      }

      this.ticketChartInstances[gameId] = new Chart(ctx, {
        type: 'bar',
        data: {
          labels,
          datasets: [{ label: 'Număr bilete', data }]
        },
        options: {
          responsive: true,
          plugins: {
            legend: { display: false },
            tooltip: { enabled: true }
          },
          scales: {
            x: { title: { display: true, text: 'Tip bilet' } },
            y: { title: { display: true, text: 'Număr bilete' }, beginAtZero: true }
          }
        }
      });
    }, 0);
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
      queryParams: { teamName: this.team.teamName }});
  }

  editGame(gameId: number, event: MouseEvent) {
    event.stopPropagation(); // să nu se închidă marcatorii la click!
    this.router.navigate(['/admin/games'], {
      queryParams: { editGameId: gameId }
    });
  }

  isHomeGame(game: Game): boolean {
    return game.game_HomeTeamId === this.teamId;
  }

  private buildGoalsDistribution(): void {
    // filtrează doar meciurile jucate
    const playedGames = this.games.filter(g => g.isPlayed);
    this.numMatchesPlayed = playedGames.length;

    // resetează map-ul și totalul golurilor
    this.goalsPerPlayer = {};
    this.totalTeamGoals = 0;

    if (playedGames.length === 0) {
      // nu avem meciuri jucate → nu construim chart
      return;
    }

    // pentru fiecare meci jucat, creează un Observable care preia scoreri
    const scorersObservables = playedGames.map(game =>
      this.playerStatsService.getScorersByGame(game.id).pipe(
        // dacă serverul răspunde 404 (niciun marcator), transformă în array gol
        catchError(err => {
          if (err.status === 404) {
            return of([] as GameScorer[]);
          }
          // pentru orice altă eroare, propagăm mai departe
          return throwError(err);
        })
      )
    );

    // așteaptă să vină TOATE răspunsurile (chiar și cele cu array gol)
    forkJoin(scorersObservables).subscribe({
      next: (allScorersPerGame: GameScorer[][]) => {
        // allScorersPerGame este un array de array-uri: fiecare element corespunde
        // unui joc din playedGames, în aceeași ordine.
        allScorersPerGame.forEach(scorers => {
          scorers.forEach(scorer => {
            // Adunăm golurile doar pentru jucătorii echipei curente
            if (scorer.teamName === this.team.teamName) {
              if (!this.goalsPerPlayer[scorer.playerName]) {
                this.goalsPerPlayer[scorer.playerName] = scorer.goals;
              } else {
                this.goalsPerPlayer[scorer.playerName] += scorer.goals;
              }
              this.totalTeamGoals += scorer.goals;
            }
          });
        });
        // după ce am agregat totul, construim chart-ul
        this.renderGoalsPieChart();
      },
      error: err => {
        console.error('Eroare la încărcarea marcatorilor (forkJoin):', err);
      }
    });
  }


private renderGoalsPieChart(): void {
  const labels = Object.keys(this.goalsPerPlayer);
  const dataValues = labels.map(name => this.goalsPerPlayer[name]);

  // generăm un array de culori HSL, câte unul pentru fiecare label
  const backgroundColors = labels.map((_, idx) => {
    const hue = Math.round((idx * 360) / labels.length);
    return `hsl(${hue}, 70%, 60%)`;
  });

  const canvasEl = document.getElementById('goalsPieChart') as HTMLCanvasElement;
  if (!canvasEl) return;
  const ctx = canvasEl.getContext('2d');
  if (!ctx) return;

  if (this.goalsPieChartInstance) {
    this.goalsPieChartInstance.destroy();
  }

  this.goalsPieChartInstance = new Chart(ctx, {
    type: 'pie',
    data: {
      labels,
      datasets: [
        {
          data: dataValues,
          backgroundColor: backgroundColors,
          borderColor: '#ffffff',
          borderWidth: 2
        }
      ]
    },
    options: {
      responsive: true,
      plugins: {
        title: {
          display: true,
          // afișăm atât numărul de meciuri, cât și totalul de goluri
          text: `Număr meciuri: ${this.numMatchesPlayed}   •   Total goluri: ${this.totalTeamGoals}`
        },
        legend: {
          position: 'right'
        },
        tooltip: {
          callbacks: {
            label: ctx => {
              const player = ctx.label || '';
              const goals = ctx.parsed as number;
              const percent = this.totalTeamGoals > 0
                ? ((goals / this.totalTeamGoals) * 100).toFixed(1) + '%'
                : '';
              return `${player}: ${goals} goluri (${percent})`;
            }
          }
        }
      }
    }
  });
}

  selectTab(tabName: 'lot' | 'program' | 'clasament'): void {
    this.activeMainTab = tabName;

    // dacă tocmai am comutat pe “lot”, reconstrui pie-chart-ul după ce DOM-ul s-a updatat
    if (tabName === 'lot') {
      setTimeout(() => {
        this.renderGoalsPieChart();
      }, 0);
    }
  }
}
