import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game } from '../models/games-model';

@Injectable({ providedIn: 'root' })
export class GamesService {
  private apiUrl = 'https://localhost:5000/api/Games';

  constructor(private http: HttpClient) {}

  getGamesByTeam(teamId: number): Observable<Game[]> {
    return this.http.get<Game[]>(`${this.apiUrl}/byTeam/${teamId}`);
  }
  
  getGames(): Observable<Game[]> {
    return this.http.get<Game[]>(`${this.apiUrl}/withNames`);
  }

  getGamesByCompetition(competitionId: number) {
    return this.http.get<Game[]>(`${this.apiUrl}/byCompetition/${competitionId}`);
  }

  addGame(game: any): Observable<any> {
    return this.http.post(this.apiUrl, game);
  }

  updateGame(game: any): Observable<any> {
    return this.http.put(this.apiUrl, game);
  }

  deleteGame(gameId: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${gameId}`);
  }

}
