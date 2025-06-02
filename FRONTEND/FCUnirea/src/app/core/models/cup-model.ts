import { Game } from "./games-model";

// cup-model.ts
export interface BracketMatch {
  homeTeam: string;
  awayTeam: string;
  firstLeg: Game;
  secondLeg?: Game;
  aggregateScore?: string;
  winner?: string;
}

export interface CupRound {
  name: string;
  matches: BracketMatch[];
}
