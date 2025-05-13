import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GameScorer } from '../models/game-scorer-model';

@Injectable({
  providedIn: 'root'
})
export class PlayerStatisticsPerGameService {
  private apiUrl = 'https://localhost:5000/api/PlayerStatisticsPerGame';

  constructor(private http: HttpClient) {}

  getScorersByGame(gameId: number): Observable<GameScorer[]> {
    return this.http.get<GameScorer[]>(`${this.apiUrl}/scorersByGame/${gameId}`);
  }

  addScorer(scorer: {
    goals: number;
    playerStatisticsPerGame_PlayersId: number;
    playerStatisticsPerGame_GamesId: number;
  }): Observable<any> {
    return this.http.post(`${this.apiUrl}`, scorer);
  }

  deleteScorer(statId: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${statId}`);
  }
}
