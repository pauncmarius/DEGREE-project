export interface Game {
    id: number;
    gameDate: string;
    homeTeamScore: number;
    awayTeamScore: number;
    game_HomeTeamId: number;
    game_AwayTeamId: number;
    game_CompetitionsId: number;
    isPlayed: boolean;

    homeTeamName: string;
    awayTeamName: string;
    competitionName: string; // 👈 Nou

  }
  